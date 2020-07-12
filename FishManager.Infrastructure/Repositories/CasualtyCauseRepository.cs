using System;
using System.Collections.Generic;
using System.Linq;
using FishManager.Domain.Entities;
using FishManager.Domain.Repositories;
using FishManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FishManager.Infrastructure.Repositories
{
    public class CasualtyCauseRepository : IRepository<CasualtyCause>
    {
        private FishManagerContext _context;
        public CasualtyCauseRepository(FishManagerContext context)
        {
            _context = context;
        }

        public U FindOne<U>(Func<CasualtyCause, bool> predicate)
        {
            return FindOne(predicate, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public U FindOne<U>(Func<CasualtyCause, bool> predicate, Func<CasualtyCause, U> projector)
        {
            try
            {
                return _context.CasualtyCauses
                    .Include(cc => cc.Casualties)
                    .Where(predicate)
                    .Select(projector)
                    .First();
            }
            catch (InvalidOperationException)
            {
                return default(U);
            }

        }

        public U FindOneOrCreate<U>(Func<CasualtyCause, bool> predicate, CasualtyCause value, Func<CasualtyCause, U> projector)
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

        public U FindOneOrCreate<U>(Func<CasualtyCause, bool> predicate, CasualtyCause value)
        {
            return FindOneOrCreate(predicate, value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> FindAll<U>(Func<CasualtyCause, bool> predicate)
        {
            return FindAll(predicate, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> FindAll<U>(Func<CasualtyCause, bool> predicate, Func<CasualtyCause, U> projector)
        {
            return _context.CasualtyCauses.Where(predicate)
                .Select(projector);
        }


        public U InsertOne<U>(CasualtyCause value, Func<CasualtyCause, U> projector)
        {
            _context.CasualtyCauses.Add(value);
            _context.SaveChanges();

            return FindOne(sp => sp.Id == value.Id, projector);
        }

        public U InsertOne<U>(CasualtyCause value)
        {
            return InsertOne(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> InsertAll<U>(IEnumerable<CasualtyCause> values, Func<CasualtyCause, U> projector)
        {

            _context.CasualtyCauses.AddRange(values);
            _context.SaveChanges();

            return FindAll(f => values.Select(ff => ff.Id).Contains(f.Id), projector);
        }

        public IEnumerable<U> InsertAll<U>(IEnumerable<CasualtyCause> values)
        {
            return InsertAll(values, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public U UpdateOne<U>(CasualtyCause value, Func<CasualtyCause, U> projector)
        {

            _context.CasualtyCauses.Update(value);
            _context.SaveChanges();

            return FindOne(f => f.Id == value.Id, projector);
        }

        public U UpdateOne<U>(CasualtyCause value)
        {
            return UpdateOne(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> UpdateAll<U>(IEnumerable<CasualtyCause> values, Func<CasualtyCause, U> projector)
        {

            _context.CasualtyCauses.UpdateRange(values);
            _context.SaveChanges();

            return FindAll(f => values.Select(ff => ff.Id).Contains(f.Id), projector);
        }

        public IEnumerable<U> UpdateAll<U>(IEnumerable<CasualtyCause> value)
        {
            return UpdateAll(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public void DeleteOne(Func<CasualtyCause, bool> predicate)
        {

            var toDelete = _context.CasualtyCauses.Where(predicate)
                        .First();

            _context.CasualtyCauses.Remove(toDelete);
            _context.SaveChanges();

        }

        public void DeleteAll(Func<CasualtyCause, bool> predicate)
        {

            _context.CasualtyCauses.RemoveRange(_context.CasualtyCauses.Where(predicate));
            _context.SaveChanges();

        }
    }
}