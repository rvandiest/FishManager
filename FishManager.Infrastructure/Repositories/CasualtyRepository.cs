using System;
using System.Collections.Generic;
using System.Linq;
using FishManager.Domain.Entities;
using FishManager.Domain.Repositories;
using FishManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FishManager.Infrastructure.Repositories
{
    public class CasualtyRepository : IRepository<Casualty>
    {
        private FishManagerContext _context;
        public CasualtyRepository(FishManagerContext context)
        {
            _context = context;
        }

        public U FindOne<U>(Func<Casualty, bool> predicate)
        {
            return FindOne(predicate, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public U FindOne<U>(Func<Casualty, bool> predicate, Func<Casualty, U> projector)
        {
            return _context.Casualties
                .Include(cs => cs.CasualtyCause)
                .Include(cs => cs.Species)
                .Where(predicate)
                .Select(projector)
                .First();
        }

        public U FindOneOrCreate<U>(Func<Casualty, bool> predicate, Casualty value, Func<Casualty, U> projector)
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

        public U FindOneOrCreate<U>(Func<Casualty, bool> predicate, Casualty value)
        {
            return FindOneOrCreate(predicate, value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> FindAll<U>(Func<Casualty, bool> predicate)
        {
            return FindAll(predicate, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> FindAll<U>(Func<Casualty, bool> predicate, Func<Casualty, U> projector)
        {
            return _context.Casualties
                .Include(cs => cs.CasualtyCause)
                .Include(cs => cs.Species)
                .Where(predicate)
                .Select(projector);
        }


        public U InsertOne<U>(Casualty value, Func<Casualty, U> projector)
        {
            _context.Casualties.Add(value);
            _context.SaveChanges();

            return FindOne(sp => sp.Id == value.Id, projector);
        }

        public U InsertOne<U>(Casualty value)
        {
            return InsertOne(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> InsertAll<U>(IEnumerable<Casualty> values, Func<Casualty, U> projector)
        {

            _context.Casualties.AddRange(values);
            _context.SaveChanges();

            return FindAll(f => values.Select(ff => ff.Id).Contains(f.Id), projector);
        }

        public IEnumerable<U> InsertAll<U>(IEnumerable<Casualty> values)
        {
            return InsertAll(values, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public U UpdateOne<U>(Casualty value, Func<Casualty, U> projector)
        {

            _context.Casualties.Update(value);
            _context.SaveChanges();

            return FindOne(f => f.Id == value.Id, projector);
        }

        public U UpdateOne<U>(Casualty value)
        {
            return UpdateOne(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> UpdateAll<U>(IEnumerable<Casualty> values, Func<Casualty, U> projector)
        {

            _context.Casualties.UpdateRange(values);
            _context.SaveChanges();

            return FindAll(f => values.Select(ff => ff.Id).Contains(f.Id), projector);
        }

        public IEnumerable<U> UpdateAll<U>(IEnumerable<Casualty> value)
        {
            return UpdateAll(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public void DeleteOne(Func<Casualty, bool> predicate)
        {

            var toDelete = _context.Casualties.Where(predicate)
                        .First();

            _context.Casualties.Remove(toDelete);
            _context.SaveChanges();

        }

        public void DeleteAll(Func<Casualty, bool> predicate)
        {

            _context.Casualties.RemoveRange(_context.Casualties.Where(predicate));
            _context.SaveChanges();

        }
    }
}