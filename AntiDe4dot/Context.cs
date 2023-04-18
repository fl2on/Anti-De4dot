using dnlib.DotNet;

namespace AntiDe4dot
{
    public class Context
    {
        public Context(AssemblyDef asm)
        {
            Assembly = asm;
            ManifestModule = asm.ManifestModule;
            GlobalType = ManifestModule.GlobalType;
            Imp = new Importer(ManifestModule);
            cctor = GlobalType.FindOrCreateStaticConstructor();
        }

        public readonly AssemblyDef Assembly;
        public readonly ModuleDef ManifestModule;
        public readonly TypeDef GlobalType;
        public readonly Importer Imp;
        public readonly MethodDef cctor;
    }
}