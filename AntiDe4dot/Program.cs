using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace AntiDe4dot
{
    internal class Program
    {
        public static void RenameTypes(Context context, int numTypes)
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[8];
                foreach (ModuleDef module in context.Assembly.Modules)
                {
                    InterfaceImpl globalItem = new InterfaceImplUser(module.GlobalType);
                    for (int i = 0; i < numTypes; i++)
                    {
                        rng.GetBytes(buffer);
                        string typeName = $"Type_{BitConverter.ToString(buffer).Replace("-", "").Substring(0, 16)}_Qzxtu";
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
                        assemblyCompanyAttr.ConstructorArguments.Add(new CAArgument(module.CorLibTypes.String, "Qzxtu Anti-D4dot"));
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

        private static void Main(string[] args)
        {
            string inputFilePath = args.FirstOrDefault();
            if (string.IsNullOrEmpty(inputFilePath))
            {
                Console.WriteLine("Please enter the path to the file you want to protect:");
                inputFilePath = Console.ReadLine().Trim();

                if (!File.Exists(inputFilePath))
                {
                    Console.WriteLine($"File {inputFilePath} does not exist.");
                    return;
                }
            }

            string outputFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath), Path.GetFileNameWithoutExtension(inputFilePath) + "-Anti_D4dot.exe");

            AssemblyDef assemblyDef = null;
            try
            {
                assemblyDef = AssemblyDef.Load(inputFilePath);
            }
            catch (Exception ex)
            {
                PrintMessage("Error loading assembly: " + ex.Message, ConsoleColor.Red);
                return;
            }

            Context context = new Context(assemblyDef);
            int numTypes = 100;
            RenameTypes(context, numTypes);

            ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(context.ManifestModule)
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

        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}