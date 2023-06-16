namespace WebApplication1
{
    public class JobRepository: IJobRepository
    {
        public  IEnumerable<JobConfig> GetJobConfigs()
        {
            // Créez votre liste de configurations de jobs ici
            List<JobConfig> jobConfigs = new List<JobConfig>
            {
                new JobConfig
                {
                    JobType = typeof(YourJobClass),
                    JobName = "JobName1",
                    TriggerName = "TriggerName1",
                    CronExpression = "0/10 * * * * ?", // Exemple de expression cron pour exécuter tous les jours à 12h00
                },
                // Ajoutez d'autres configurations de jobs si nécessaire
            };

            return jobConfigs;
        }
       
    }

    public interface IJobRepository
    {
         IEnumerable<JobConfig> GetJobConfigs();
    }
}
