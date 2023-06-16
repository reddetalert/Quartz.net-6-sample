using Quartz;

namespace WebApplication1
{
    public class YourJobClass : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            // Logique de votre job ici
            Console.WriteLine("Job exécuté!");

            return Task.CompletedTask;
        }
    }
}
