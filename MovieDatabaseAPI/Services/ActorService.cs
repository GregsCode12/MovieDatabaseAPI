using Microsoft.AspNetCore.Http.HttpResults;
using MovieDatabaseAPI.Data;
using MovieDatabaseAPI.Data.Models;

namespace MovieDatabaseAPI.Services
{
    public class ActorService
    {
        private AppDbContext _context;

        public ActorService(AppDbContext context) { 
            _context = context;
        }

        public List<Data.Models.Actor> FetchActorsPagination(int page, int pageSize)
        {
            int offset = pageSize - 1 * page;
            var actors = _context.Actors.Skip(offset).Take(pageSize).ToList();
            foreach(var actor in actors)
            {
                _context.Entry(actor).Collection(p => p.Movies).Load();
            }
            return actors;
        }

        public List<Data.Models.Actor> FetchActors()
        {
            foreach(var actor in _context.Actors)
            {
                _context.Entry(actor).Collection(p => p.Movies).Load();
            }
            return _context.Actors.ToList();
        }

        public Data.Models.Actor? GetActorById(int actorId)
        {
            var actor = _context.Actors.FirstOrDefault(n => n.Id == actorId);
            if(actor != null)
            {
                _context.Entry(actor).Collection(p => p.Movies).Load();
            }
            return actor;
        }

        public void AddActor(Data.Models.Actor actor)
        {
            var _actor = new Data.Models.Actor()
            {
                Name = actor.Name,
                Surname = actor.Surname,
                DateOfBirth = actor.DateOfBirth,
                Movies = actor.Movies,
            };
            _context.Actors.Add(_actor);
            _context.SaveChanges();
        }

        public Data.Models.Actor? EditActorById(int actorId, Data.Models.Actor actor)
        {
            var _actor = _context.Actors.FirstOrDefault(n => n.Id == actorId);
            if(_actor != null)
            {
                _actor.Name = actor.Name;
                _actor.Surname = actor.Surname;
                _actor.DateOfBirth = actor.DateOfBirth;
                _actor.Movies = actor.Movies;
                _context.SaveChanges();
            }
            return _actor;
        }
        public Data.Models.Actor? DeleteActorById(int actorId)
        {
            var _actor = _context.Actors.FirstOrDefault(n => n.Id == actorId);
            if(_actor!=null)
            {
                _context.Remove(_actor);
                _context.SaveChanges();
            }
            return _actor;
        }
    }
}
