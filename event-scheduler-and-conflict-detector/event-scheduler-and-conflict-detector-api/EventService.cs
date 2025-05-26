using event_scheduler_and_conflict_detector_api.Models;
using Microsoft.Extensions.Logging;

namespace event_scheduler_and_conflict_detector_api
{
    public class EventService : IEventService
    {
        private readonly Dictionary<Guid, Event> _events;

        public EventService()
        {
            var events = new List<Event>
            {
                new Event(new Guid("id"), "Staff meeting", "For ", new DateTime(2025, 5, 26), new DateTime(2025, 5, 27), "Conference Room", new List<string> { "Ridwan", "Sydney" }),
                new Event(new Guid("id"), "Doctors Appointment", "", new DateTime(2025, 5, 26), new DateTime(2025, 5, 27), "General Hospital", new List<string> { "Ridwan", "Toba" }),
                new Event(new Guid("id"), "General meeting", "", new DateTime(2025, 5, 26), new DateTime(2025, 5, 27), "Office premises", new List<string> { "Ridwan", "Zanna" })
            };

            _events = events.ToDictionary(p => p.Id);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _events.Values;
        }
        public List<Event> GetEventByDateTime(DateTime date)
        {
            return _events
               // .Where(x => x.Value.Date >= startDate.Date && x.Value.Date <= endDate.Date)
                .Select(x => x.Value)
                .ToList();
        }


        public void AddEvent(Event newEvent)
        {
            if (string.IsNullOrEmpty(newEvent.Title))
                throw new ArgumentException("Event title cannot be empty");

            // Example: check if an event with the same title already exists

        }

        //public void UpdateEvent(Event events)
        //{
        //    var existingEvent = eventList.FirstOrDefault(e => e.Id == updateEvent.Id);
        //    if (existingEvent != null)
        //    {
        //        existingEvent.Title = updateEvent.Title;
        //        existingEvent.Description = updatedEvent.Description;
        //        existingEvent.Location = updatedEvent.Location;
        //        existingEvent.Attendees = updatedEvent.Attendees;
        //    }
        //}

        public void UpdateEvent(Event events)
        {
            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            if (_events.ContainsKey(events.Id))
            {
                throw new KeyNotFoundException("Event not found");
            }
        }

       // List<Event> eventList = new List<Event>();
        public bool DeleteEvent(Guid id)
        {
            return _events.Remove(id);
        }
    }
}

