using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Track_Time.EF;
using Track_Time.Models;

namespace Track_Time.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrackTimeController : ControllerBase
    {
        ContextData db = new ContextData();
        [HttpGet("{personId}/{dateTime}")]
        public async Task<ActionResult<TrackTime>> GetTrackTimesByDateTime(int personId, DateTime dateTime )
        {
            List<TrackTime> trackTimes = await (from trackTime in db.TrackTimes.Include(p => p.ActivityType).Include(p=>p.Employee)
                              .Include(p=>p.Project).Include(p=>p.Role)
                          where trackTime.Employee.Id == personId && 
                          trackTime.DateEvent.Date == dateTime.Date 
                                          select trackTime).ToListAsync();

            if (trackTimes.Count == 0)
                return NotFound();

            StringBuilder stringBuilder = new StringBuilder();

            bool flag = true;
            foreach (var track in trackTimes)
            {
                if (flag)
                {
                    stringBuilder.Append(track.DateEvent.Date.ToString("d") + " as a ");
                    stringBuilder.Append(track.Role.Name + " I worked on the ");
                    stringBuilder.Append(track.Project.Name + " ");
                    stringBuilder.Append(track.WorkingHours.Hours + " hours ");
                    stringBuilder.Append(track.ActivityType.Name);
                    flag = false;
                }
                else
                {
                    stringBuilder.Append(" and " + track.WorkingHours.Hours + " hours as a ");
                    stringBuilder.Append(track.Role.Name + " on the ");
                    stringBuilder.Append(track.Project.Name + " ");
                    stringBuilder.Append(track.ActivityType.Name);
                }

            }
            return new ObjectResult(stringBuilder.ToString());
        }
        private DateTime GetBeginDateOfWeek(int weekNumber)
        {
            DateTime firstDay = new DateTime(DateTime.Now.Year, 1, 1); //1 января этого года
            while (firstDay.DayOfWeek != DayOfWeek.Thursday) firstDay = firstDay.AddDays(1); //ближайший четверг первая неделя года, стандарт в Европе
            return firstDay.AddDays(7 * (weekNumber - 1) - 3);
        }
        [HttpGet("NumberOfWeek/{personId}/{numberOfWeek}")]
        public async Task<ActionResult<TrackTime>> GetTrackTimesByNumberWeek(int personId, int numberOfWeek )
        {
            DateTime firstDayOfWeek = GetBeginDateOfWeek(numberOfWeek);
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

            List<TrackTime> trackTimes = await (from trackTime in db.TrackTimes.Include(p => p.ActivityType).Include(p => p.Employee)
                  .Include(p => p.Project).Include(p => p.Role)
                                                where trackTime.Employee.Id == personId &&
                                                trackTime.DateEvent.Date >= firstDayOfWeek &&
                                                lastDayOfWeek >=  trackTime.DateEvent.Date
                                                select trackTime).ToListAsync();

            if (trackTimes.Count == 0)
                return NotFound();

            StringBuilder stringBuilder = new StringBuilder();

            bool flag = true;
            foreach (var track in trackTimes)
            {
                if (flag)
                {
                    stringBuilder.Append(track.DateEvent.Date.ToString("d") + " as a ");
                    stringBuilder.Append(track.Role.Name + " I worked on the ");
                    stringBuilder.Append(track.Project.Name + " ");
                    stringBuilder.Append(track.WorkingHours.Hours + " hours ");
                    stringBuilder.Append(track.ActivityType.Name);
                    flag = false;
                }
                else
                {
                    stringBuilder.Append(" and " + track.WorkingHours.Hours + " hours as a ");
                    stringBuilder.Append(track.Role.Name + " on the ");
                    stringBuilder.Append(track.Project.Name + " ");
                    stringBuilder.Append(track.ActivityType.Name);
                }

            }
            return new ObjectResult(stringBuilder.ToString());
        }
    }
}
