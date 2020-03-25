using Ninject;
using Register.Business.Layer.Module;

namespace Register.Cli.Layer
{
    public class Program
    {
        private static void Main()
        {
            IKernel kernel = new StandardKernel(new ServiceModule(), new ProgramLoopModule(), new RepositoryModule());
            kernel.Get<ProgramLoop>().Execute();
        }
    }
}
