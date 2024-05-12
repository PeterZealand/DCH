using DCH.Helpers;
using DCH.Models;

namespace DCH.Services
{
    public class EventJson
    {
        string JsonFileName = @"C:\Users\eriki\OneDrive - Zealand\Semester 1\Afleveringer\DCH\DCH\DCH\Data\JsonEvents.json";
        public Dictionary<int, Event> AllEvents()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }
        public Event GetEvents(int id)
        {
            Dictionary<int, Event> events = AllEvents();
            return events[id];
        }
    }
}
