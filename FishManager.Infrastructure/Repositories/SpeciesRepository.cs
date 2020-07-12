using System;
using System.Collections.Generic;
using System.Linq;
using FishManager.Domain.Entities;
using FishManager.Domain.Repositories;
using FishManager.Infrastructure.Contexts;

namespace FishManager.Infrastructure.Repositories
{
    public class SpeciesRepository : IRepository<Species>
    {
        private FishManagerContext _context;
        public SpeciesRepository(FishManagerContext context)
        {
            _context = context;
        }

        public U FindOne<U>(Func<Species, bool> predicate)
        {
            return FindOne(predicate, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public U FindOne<U>(Func<Species, bool> predicate, Func<Species, U> projector)
        {
            try
            {
                return _context.Species
                    .Where(predicate)
                    .Select(projector)
                    .First();
            }
            catch (InvalidOperationException)
            {
                return default(U);
            }

        }

        public U FindOneOrCreate<U>(Func<Species, bool> predicate, Species value, Func<Species, U> projector)
        {
            var existing = FindOne(predicate, projector);
            if (existing != null)
            {
                return existing;
            }
            else
            {
                return InsertOne(value, projector);
            }
        }

        public U FindOneOrCreate<U>(Func<Species, bool> predicate, Species value)
        {
            return FindOneOrCreate(predicate, value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> FindAll<U>(Func<Species, bool> predicate)
        {
            return FindAll(predicate, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> FindAll<U>(Func<Species, bool> predicate, Func<Species, U> projector)
        {
            return _context.Species.Where(predicate)
                .Select(projector);
        }


        public U InsertOne<U>(Species value, Func<Species, U> projector)
        {
            _context.Species.Add(value);
            _context.SaveChanges();

            return FindOne(sp => sp.Id == value.Id, projector);
        }

        public U InsertOne<U>(Species value)
        {
            return InsertOne(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> InsertAll<U>(IEnumerable<Species> values, Func<Species, U> projector)
        {

            _context.Species.AddRange(values);
            _context.SaveChanges();

            return FindAll(f => values.Select(ff => ff.Id).Contains(f.Id), projector);
        }

        public IEnumerable<U> InsertAll<U>(IEnumerable<Species> values)
        {
            return InsertAll(values, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public U UpdateOne<U>(Species value, Func<Species, U> projector)
        {

            _context.Species.Update(value);
            _context.SaveChanges();

            return FindOne(f => f.Id == value.Id, projector);
        }

        public U UpdateOne<U>(Species value)
        {
            return UpdateOne(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> UpdateAll<U>(IEnumerable<Species> values, Func<Species, U> projector)
        {

            _context.Species.UpdateRange(values);
            _context.SaveChanges();

            return FindAll(f => values.Select(ff => ff.Id).Contains(f.Id), projector);
        }

        public IEnumerable<U> UpdateAll<U>(IEnumerable<Species> value)
        {
            return UpdateAll(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public void DeleteOne(Func<Species, bool> predicate)
        {

            var toDelete = _context.Species.Where(predicate)
                        .First();

            _context.Species.Remove(toDelete);
            _context.SaveChanges();

        }

        public void DeleteAll(Func<Species, bool> predicate)
        {

            _context.Species.RemoveRange(_context.Species.Where(predicate));
            _context.SaveChanges();

        }
    }
}