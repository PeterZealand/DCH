using DCH.Interfaces;
using DCH.Models;
using DCH.Helpers;
using Microsoft.Extensions.Logging;

namespace DCH.Services
{
    public class ActorJson : IActorRepository
    {
        string JsonFileName = @"C:\Users\eriki\OneDrive - Zealand\Semester 1\Afleveringer\DCH\DCH\DCH\Data\JsonActors.json";
        //C:\Users\eriki\OneDrive - Zealand\Semester 1\Afleveringer\DCH\DCH\DCH\Data\JsonEvents.json

        private readonly Dictionary<int, Actor> actors = new Dictionary<int, Actor>();
        private int currentId = 0;

        public ActorJson()
        {
            actors = AllActors();

            if (actors.Keys.Any())
            {
                currentId = actors.Keys.Max() + 1;
            }
            else
            {
                currentId = 0;
            }
        }


        public void AddActor(Actor Actor)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Actor> AllActors()
        {
            throw new NotImplementedException();
        }

        public void DeleteActor(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Actor> FilterActors(string criteria)
        {
            throw new NotImplementedException();
        }

        public Event GetActors(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateActor(Actor Actor)
        {
            throw new NotImplementedException();
        }
    }
}
