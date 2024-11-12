using dnlib.DotNet;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace AntiDe4dot
{
    internal abstract class Program
    {
        public static void Main(string[] args)
        {
            var inputFilePath = args.FirstOrDefault();
            if (string.IsNullOrEmpty(inputFilePath))
            {
                Console.WriteLine("Please enter the path to the file you want to protect:");
                inputFilePath = Console.ReadLine()?.Trim();

                if (!File.Exists(inputFilePath))
                {
                    Console.WriteLine($"File {inputFilePath} does not exist.");
                    return;
                }
            }

            var isNetCore = IsNetCoreApp(inputFilePath);

            var outputExtension = isNetCore ? ".dll" : ".exe";
            var outputFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath) ?? string.Empty, Path.GetFileNameWithoutExtension(inputFilePath) + "-Anti_D4dot" + outputExtension);

            if (IsNetCoreApp(inputFilePath))
            {
                var exePath = Path.ChangeExtension(inputFilePath, ".exe");
                if (File.Exists(exePath))
                {
                    var outputExePath = Path.Combine(Path.GetDirectoryName(inputFilePath) ?? string.Empty, Path.GetFileNameWithoutExtension(inputFilePath) + "-Anti_D4dot.exe");
                    if (exePath != null) File.Copy(exePath, outputExePath, true);
                }

                var dllPath = Path.ChangeExtension(inputFilePath, ".dll");
                inputFilePath = dllPath;

            }

            ModuleDefMD moduleDef;
            try
            {
                moduleDef = ModuleDefMD.Load(inputFilePath);
            }
            catch (Exception ex)
            {
                PrintMessage("Error loading assembly: " + ex.Message, ConsoleColor.Red);
                return;
            }

            var context = new Context(moduleDef);
            const int numTypes = 100;
            RenameTypes(context, numTypes);

            var writerOptions = new dnlib.DotNet.Writer.ModuleWriterOptions(moduleDef)
            {
                Logger = DummyLogger.NoThrowInstance
            };

            try
            {
                moduleDef.Write(outputFilePath, writerOptions);
                PrintMessage("Done. File saved as " + outputFilePath, ConsoleColor.Cyan);
            }
            catch (Exception ex)
            {
                PrintMessage("Error writing anti d4dot assembly: " + ex.Message, ConsoleColor.Red);
            }

            PrintMessage("Press any key to exit.");
            Console.ReadKey();
        }
        
        private static bool IsNetCoreApp(string filePath)
        {
            if (Path.GetExtension(filePath).Equals(".exe", StringComparison.OrdinalIgnoreCase))
            {
                var dllPath = Path.ChangeExtension(filePath, ".dll");
                if (File.Exists(dllPath))
                {
                    try
                    {
                        var module = ModuleDefMD.Load(dllPath);
                        return module.GetAssemblyRefs().Any(r => r.Name == "System.Runtime");
                    }
                    catch (BadImageFormatException)
                    {
                        return true;
                    }
                }
            }

            try
            {
                var module = ModuleDefMD.Load(filePath);
                return module.IsILOnly && IsNetCoreAssembly(module);
            }
            catch (BadImageFormatException)
            {
                return false;
            }
        }

        private static bool IsNetCoreAssembly(ModuleDef module)
        {
            return module.GetAssemblyRefs().Any(r => r.Name == "System.Runtime");
        }

        private static void RenameTypes(Context context, int numTypes)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var buffer = new byte[8];
                foreach (var module in context.ModuleDef.Assembly.Modules)
                {
                    var globalType = module.GlobalType;
                    if (globalType == null)
                        continue;

                    var globalItem = new InterfaceImplUser(globalType);

                    for (var i = 0; i < numTypes; i++)
                    {
                        rng.GetBytes(buffer);
                        var typeName = $"Type_{BitConverter.ToString(buffer).Replace("-", "").Substring(0, 16)}_Qzxtu";
                        var newTypeDef = new TypeDefUser(string.Empty, typeName, module.CorLibTypes.GetTypeRef("System", "Attribute"));
                        var newInterfaceImpl = new InterfaceImplUser(newTypeDef);
                        module.Types.Add(newTypeDef);
                        newTypeDef.Interfaces.Add(newInterfaceImpl);
                        newTypeDef.Interfaces.Add(globalItem);
                    }

                    var assemblyCompanyAttr = module.Assembly.CustomAttributes.SingleOrDefault(a => a.AttributeType.FullName == "System.Reflection.AssemblyCompanyAttribute");
                    if (assemblyCompanyAttr != null)
                    {
                        assemblyCompanyAttr.ConstructorArguments.Clear();
                        assemblyCompanyAttr.ConstructorArguments.Add(new CAArgument(module.CorLibTypes.String,
                            "Qzxtu Anti-D4dot"));
                    }
                    else
                    {
                        var assemblyCompanyRef = module.CorLibTypes.GetTypeRef("System.Reflection", "AssemblyCompanyAttribute");
                        var assemblyCompanyTypeDef = assemblyCompanyRef.ResolveTypeDef();
                        var assemblyCompanyCtor = assemblyCompanyTypeDef.FindConstructors().Single();
                        var assemblyCompanyAttrType = new CustomAttribute(assemblyCompanyCtor);
                        assemblyCompanyAttrType.ConstructorArguments.Add(new CAArgument(module.CorLibTypes.String, "Qzxtu Anti-D4dot"));
                        module.Assembly.CustomAttributes.Add(assemblyCompanyAttrType);
                    }
                }
            }
        }

        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
