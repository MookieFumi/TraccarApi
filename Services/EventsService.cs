using System.Collections.Generic;
using System.Linq;
using TraccarApi.Business;
using TraccarApi.Business.Entities;

namespace TraccarApi.Services
{
    public class EventsService : IEventsService
    {
        public const string ALARM_GEOFENCE_EXIT = "geofenceExit";
        public const string ALARM_POWER_ON = "powerOn";
        private static string[] _events = new string[] { ALARM_GEOFENCE_EXIT, ALARM_POWER_ON };

        private TraccarContext _context;

        public EventsService(TraccarContext context)
        {
            _context = context;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        public Event GetEvents(int id)
        {
            return _context.Events.Find(id);
        }
    }
}