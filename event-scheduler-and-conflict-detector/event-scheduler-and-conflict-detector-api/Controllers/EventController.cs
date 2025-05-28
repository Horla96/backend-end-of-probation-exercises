using event_scheduler_and_conflict_detector_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace event_scheduler_and_conflict_detector_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            var events = _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{DateTime}")]
        public ActionResult<Event> GetEventByDateTime(DateTime date)
        {
            var events = _eventService.GetEventByDateTime(date);
            return Ok(events);
        }

        [HttpPost]

        public ActionResult AddEvent(Event events)
        {
            _eventService.AddEvent(events);
            return Ok();

        }

        [HttpPut("Id")]
        public ActionResult UpdateEvent(Event events)
        {
            _eventService.UpdateEvent(events);
            return Ok();
        }

        [HttpDelete("Id")]
        public ActionResult DeleteEvent(Guid Id)
        {
            _eventService.DeleteEvent(Id);
            return Ok();
        }

     
    }

}

