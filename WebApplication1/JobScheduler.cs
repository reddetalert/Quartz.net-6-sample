using Quartz;

namespace WebApplication1
{
    public class JobScheduler
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobRepository _jobRepository;

        public JobScheduler(ISchedulerFactory schedulerFactory, IJobRepository jobRepository)
        {
            _schedulerFactory = schedulerFactory;
            _jobRepository = jobRepository;
        }

        public async Task ScheduleJobs()
        {
            IScheduler scheduler = await _schedulerFactory.GetScheduler();
           var _jobConfigs = _jobRepository.GetJobConfigs();
            foreach (var jobConfig in _jobConfigs)
            {
                IJobDetail jobDetail = JobBuilder.Create(jobConfig.JobType)
                    .WithIdentity(jobConfig.JobName)
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity(jobConfig.TriggerName)
                    .WithCronSchedule(jobConfig.CronExpression)
                    .Build();

                await scheduler.ScheduleJob(jobDetail, trigger);
            }
            await scheduler.Start();
        }

        public async Task ScheduleJob(string toto)
        {
            IScheduler scheduler = await _schedulerFactory.GetScheduler();
            await scheduler.TriggerJob(new JobKey("JobName1")); // Remplacez "JobName1" par le nom du job existant que vous souhaitez déclencher
        }
    }

    public class JobConfig
    {
        public Type JobType { get; set; }
        public string JobName { get; set; }
        public string TriggerName { get; set; }
        public string CronExpression { get; set; }
    }
}
