using Ninject.Modules;

namespace Register.Cli.Layer
{
    class ProgramLoopModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProgramLoop>().To<ProgramLoop>();
        }
    }
}
