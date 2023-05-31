using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace AntiDe4dot
{
    internal abstract class Program
    {
        private static void RenameTypes(Context context, int numTypes)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var buffer = new byte[8];
                foreach (var module in context.Assembly.Modules)
                {
                    InterfaceImpl globalItem = new InterfaceImplUser(module.GlobalType);
                    for (var i = 0; i < numTypes; i++)
                    {
                        rng.GetBytes(buffer);
                        var typeName = $"Type_{BitConverter.ToString(buffer).Replace("-", "").Substring(0, 16)}_Qzxtu";
                        TypeDef newTypeDef = new TypeDefUser(string.Empty, typeName, module.CorLibTypes.GetTypeRef("System", "Attribute"));
                        InterfaceImpl newInterfaceImpl = new InterfaceImplUser(newTypeDef);
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
                        var assemblyCompanyRef =
                            module.CorLibTypes.GetTypeRef("System.Reflection", "AssemblyCompanyAttribute");
                        var assemblyCompanyTypeDef = assemblyCompanyRef.ResolveTypeDef();
                        var assemblyCompanyCtor = assemblyCompanyTypeDef.FindConstructors().Single();
                        var assemblyCompanyAttrType = new CustomAttribute(assemblyCompanyCtor);
                        assemblyCompanyAttrType.ConstructorArguments.Add(new CAArgument(module.CorLibTypes.String,
                            "Qzxtu Anti-D4dot"));
                        module.Assembly.CustomAttributes.Add(assemblyCompanyAttrType);
                    }
                }
            }
        }

        private static void Main(string[] args)
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

            var outputFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath) ?? string.Empty, Path.GetFileNameWithoutExtension(inputFilePath) + "-Anti_D4dot.exe");

            AssemblyDef assemblyDef;
            try
            {
                assemblyDef = AssemblyDef.Load(inputFilePath);
            }
            catch (Exception ex)
            {
                PrintMessage("Error loading assembly: " + ex.Message, ConsoleColor.Red);
                return;
            }

            var context = new Context(assemblyDef);
            const int numTypes = 100;
            RenameTypes(context, numTypes);

            var moduleWriterOptions = new ModuleWriterOptions(context.ManifestModule)
            {
                Logger = null
            };

            try
            {
                assemblyDef.Write(outputFilePath, moduleWriterOptions);
                PrintMessage("Done. File saved as " + outputFilePath, ConsoleColor.Cyan);
            }
            catch (Exception ex)
            {
                PrintMessage("Error writing anti d4dot assembly: " + ex.Message, ConsoleColor.Red);
            }

            PrintMessage("Press any key to exit.");
            Console.ReadKey();
        }

        //Message Printer Function
        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
