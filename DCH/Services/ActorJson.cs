using DCH.Interfaces;
using DCH.Models;
using DCH.Helpers;
using Microsoft.Extensions.Logging;

namespace DCH.Services
{
    public class ActorJson : IActorRepository
    {
        string JsonFileName = @"C:\Users\eriki\OneDrive - Zealand\Semester 1\Afleveringer\DCH\DCH\DCH\Data\JsonActors.json";
        //C:\Users\eriki\OneDrive - Zealand\Semester 1\Afleveringer\DCH\DCH\DCH\Data\JsonActors.json

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
            Dictionary<int, Actor> actors = AllActors();
            actors.Remove(id);
            JsonFileWriter.WriteToJsonAc(actors, JsonFileName);
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
            Dictionary<int, Actor> actors = AllActors();
            if (Actor != null)
            {
                actors[(int)Actor.Id] = Actor;
            }
            JsonFileWriter.WriteToJsonAc(actors, JsonFileName);
        }
    }
}
