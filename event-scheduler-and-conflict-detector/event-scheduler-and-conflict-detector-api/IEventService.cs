using event_scheduler_and_conflict_detector_api.Models;

namespace event_scheduler_and_conflict_detector_api
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();
        void AddEvent(Event events);
        void UpdateEvent(Event events);
        bool DeleteEvent(Guid id);
        List<Event> GetEventByDateTime(DateTime date);
    }
}
