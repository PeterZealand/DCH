using DCH.Helpers;
using DCH.Interfaces;
using DCH.Models;

namespace DCH.Services
{
    public class EventJson : IEventRepository
    {
        string JsonFileName = @"C:\Users\mlber\Source\Repos\DCH\DCH\Data\JsonEvents.json";

        public void AddEvent(Event Event)
        {
            Dictionary<int, Event> events = AllEvents();
            if (Event != null)
            {
                events[(int)Event.Id] = Event;
            }
            JsonFileWriter.WriteToJson(events, JsonFileName);
        }

        public Dictionary<int, Event> AllEvents()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }

        public void DeleteEvent(int id)
        {
            Dictionary<int, Event> events = AllEvents();
            events.Remove(id);
            JsonFileWriter.WriteToJson(events, JsonFileName);
        }

        public Dictionary<int, Event> FilterEvents(string criteria)
        {
            throw new NotImplementedException();
        }


        public Event GetEvents(int id)
        {
            Dictionary<int, Event> events = AllEvents();
            return events[id];
        }

        //public Event GetEvents(int id)
        //{
        //    Dictionary<int, Event> events = AllEvents();
        //    return events[id];
        //}

        public void UpdateEvent(Event Event)
        {
            Dictionary<int, Event> events = AllEvents();
            if (Event != null)
            {
                events[(int)Event.Id] = Event;
            }
            JsonFileWriter.WriteToJson(events, JsonFileName);
        }
    }
}
