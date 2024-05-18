using DCH.Models;

namespace DCH.Interfaces
{
    public interface IActorRepository
    {
        Dictionary<int, Actor> AllActors();
        Dictionary<int, Actor> FilterActors(string criteria);
        void DeleteActor(int id);
        void AddActor(Actor Actor);
        void UpdateActor(Actor Actor);
        Actor GetActors(int id);
    }
}
