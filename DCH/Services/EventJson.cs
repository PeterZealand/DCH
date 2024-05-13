using DCH.Helpers;
using DCH.Interfaces;
using DCH.Models;

namespace DCH.Services
{
    public class EventJson : IEventRepository
    {
        string JsonFileName = @"C:\Users\eriki\OneDrive - Zealand\Semester 1\Afleveringer\DCH\DCH\DCH\Data\JsonEvents.json";

        public void AddEvent(Event Event)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Event> AllEvents()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }

        public void DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Event> FilterEvents(string criteria)
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Event GetEvents(int id)
        {
            Dictionary<int, Event> events = AllEvents();
            return events[id];
        }

        public void UpdateEvent(Event Event)
        {
            throw new NotImplementedException();
        }
    }
}
