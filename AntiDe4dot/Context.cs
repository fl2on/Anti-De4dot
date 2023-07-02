using dnlib.DotNet;

namespace AntiDe4dot
{
    public class Context
    {
        public Context(ModuleDefMD moduleDef)
        {
            ModuleDef = moduleDef;
            var globalType = ModuleDef.GlobalType;
            globalType.FindOrCreateStaticConstructor();
        }

        public readonly ModuleDefMD ModuleDef;
    }
}
