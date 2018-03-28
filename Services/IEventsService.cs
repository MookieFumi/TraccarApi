using System.Collections.Generic;
using TraccarApi.Business.Entities;

namespace TraccarApi.Services
{
    public interface IEventsService
    {
        IEnumerable<Event> GetEvents();
        Event GetEvents(int id);
    }
}