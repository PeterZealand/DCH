using DCH.Interfaces;
using DCH.Models;
using DCH.Helpers;
using Microsoft.Extensions.Logging;

namespace DCH.Services
{
    public class ActorJson : IActorRepository
    {
        string JsonFileName = @"C:\Users\papri\OneDrive - Zealand\Skrivebord\Projekt 1. sem\DcH\DCH\Data\JsonActors.json";
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

        public void AddActor(Actor ac)
        {
            {
                if (ac != null)
                {
                    ac.Id = currentId++;
                }
                actors[ac.Id] = ac;
                JsonFileWriter.WriteToJsonAc(actors, JsonFileName);
            }
        }

        public void AddActorIdNo(Actor ac)
            {
                ac.Id = currentId++;
            }

        

        public Dictionary<int, Actor> AllActors()
        {
            return JsonFileReader.ReadJsonAc(JsonFileName);
        }

        public void DeleteActor(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Actor> FilterActors(string criteria)
        {
            throw new NotImplementedException();
        }

        public Actor GetActors(int id)
        {
            Dictionary<int, Actor> actors = AllActors();
            return actors[id];
        }

        public void UpdateActor(Actor Actor)
        {
            throw new NotImplementedException();
        }
    }
}
