using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Entities;
using BackGroundJobs;

namespace BackgroundJobs.Schedules
{
    public static class Notification
    {
        public static string addnotification(User user, DateTime bozulma_tarihi, Food myfood, DateTime eklenme_tarihi) 
        {
            DateTime tarih;
            if (bozulma_tarihi == eklenme_tarihi || bozulma_tarihi <= eklenme_tarihi.AddDays(1))
            {
                tarih = bozulma_tarihi.AddMinutes(5);
            }
            else
            {
                tarih = bozulma_tarihi.AddHours(-24);
            }
            var jobId = BackgroundJob.Schedule<JobsPage>
            (
            Job => Job.MainJob(user, myfood),
            tarih //bozulma tarihinden 24 saat önce bildirim gönder !!!
            );
            return jobId;
        }
        public static string updatenotification(User user, string jobid, DateTime bozulma_tarihi, Food myfood, DateTime eklenme_tarihi)
        {
            DateTime tarih;
            if (bozulma_tarihi == eklenme_tarihi || bozulma_tarihi <= eklenme_tarihi.AddDays(1))
            {
                tarih = bozulma_tarihi.AddMinutes(5);
            }
            else
            {
                tarih = bozulma_tarihi.AddHours(-24);
            }
            BackgroundJob.Delete(jobid);
            var jobId = BackgroundJob.Schedule<JobsPage>
            (
            Job => Job.MainJob(user, myfood),
            tarih //bozulma tarihinden 24 saat önce bildirim gönder !!!
            );
            return jobId;
        }

        public static void deletenotification(string jobid)
        {
            BackgroundJob.Delete(jobid);
        }
    }
}

