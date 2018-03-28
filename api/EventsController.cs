using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TraccarApi.Business.Entities;
using TraccarApi.Services;

namespace TraccarApi.api
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Event> events = _eventsService.GetEvents();
            return base.Ok(events);
        }

        [HttpGet("{id}", Name = "GetEvent")]
        public IActionResult GetById(int id)
        {
            var item = _eventsService.GetEvents(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }
}