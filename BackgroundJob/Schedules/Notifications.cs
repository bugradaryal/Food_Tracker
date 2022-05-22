using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgroundJob.Managers;
using Hangfire;
using Entities;

namespace BackgroundJob.Schedules
{
    public static class Notifications
    {
        public static void sendnotification(User user)
        {
            var jobId = Hangfire.BackgroundJob.Schedule<Email>
            (
            Job => Job.SendEmail(user),
            TimeSpan.FromSeconds(20)
            );
        }
    }
}

