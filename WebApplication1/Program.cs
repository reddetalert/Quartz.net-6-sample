using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
//builder.Services.AddSingleton<IEnumerable<JobConfig>>(IJobRepository.GetJobConfigs());
builder.Services.AddSingleton<IJobRepository, JobRepository>();
builder.Services.AddSingleton<JobScheduler>();

var jobScheduler = builder.Services.BuildServiceProvider().GetRequiredService<JobScheduler>();
await jobScheduler.ScheduleJobs();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
