using dnlib.DotNet;

namespace AntiDe4dot
{
    public class Context
    {
        public Context(AssemblyDef asm)
        {
            Assembly = asm;
            ManifestModule = asm.ManifestModule;
            var globalType = ManifestModule.GlobalType;
            globalType.FindOrCreateStaticConstructor();
        }

        public readonly AssemblyDef Assembly;
        public readonly ModuleDef ManifestModule;
    }
}
