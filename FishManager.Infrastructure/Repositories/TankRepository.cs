using System;
using System.Collections.Generic;
using System.Linq;
using FishManager.Domain.Entities;
using FishManager.Domain.Repositories;
using FishManager.Infrastructure.Contexts;

namespace FishManager.Infrastructure.Repositories
{
    public class TankRepository : IRepository<Tank>
    {
        private FishManagerContext _context;
        public TankRepository(FishManagerContext context)
        {
            _context = context;
        }

        public U FindOne<U>(Func<Tank, bool> predicate)
        {
            return FindOne(predicate, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public U FindOne<U>(Func<Tank, bool> predicate, Func<Tank, U> projector)
        {
            try
            {
                return _context.Tanks
                    .Where(predicate)
                    .Select(projector)
                    .First();
            }
            catch (InvalidOperationException)
            {
                return default(U);
            }

        }

        public U FindOneOrCreate<U>(Func<Tank, bool> predicate, Tank value, Func<Tank, U> projector)
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

        public U FindOneOrCreate<U>(Func<Tank, bool> predicate, Tank value)
        {
            return FindOneOrCreate(predicate, value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> FindAll<U>(Func<Tank, bool> predicate)
        {
            return FindAll(predicate, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> FindAll<U>(Func<Tank, bool> predicate, Func<Tank, U> projector)
        {
            return _context.Tanks.Where(predicate)
                .Select(projector);
        }


        public U InsertOne<U>(Tank value, Func<Tank, U> projector)
        {
            _context.Tanks.Add(value);
            _context.SaveChanges();

            return FindOne(sp => sp.Id == value.Id, projector);
        }

        public U InsertOne<U>(Tank value)
        {
            return InsertOne(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> InsertAll<U>(IEnumerable<Tank> values, Func<Tank, U> projector)
        {

            _context.Tanks.AddRange(values);
            _context.SaveChanges();

            return FindAll(f => values.Select(ff => ff.Id).Contains(f.Id), projector);
        }

        public IEnumerable<U> InsertAll<U>(IEnumerable<Tank> values)
        {
            return InsertAll(values, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public U UpdateOne<U>(Tank value, Func<Tank, U> projector)
        {

            _context.Tanks.Update(value);
            _context.SaveChanges();

            return FindOne(f => f.Id == value.Id, projector);
        }

        public U UpdateOne<U>(Tank value)
        {
            return UpdateOne(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public IEnumerable<U> UpdateAll<U>(IEnumerable<Tank> values, Func<Tank, U> projector)
        {

            _context.Tanks.UpdateRange(values);
            _context.SaveChanges();

            return FindAll(f => values.Select(ff => ff.Id).Contains(f.Id), projector);
        }

        public IEnumerable<U> UpdateAll<U>(IEnumerable<Tank> value)
        {
            return UpdateAll(value, sp => (U)Convert.ChangeType(sp, typeof(U)));
        }

        public void DeleteOne(Func<Tank, bool> predicate)
        {

            var toDelete = _context.Tanks.Where(predicate)
                        .First();

            _context.Tanks.Remove(toDelete);
            _context.SaveChanges();

        }

        public void DeleteAll(Func<Tank, bool> predicate)
        {

            _context.Tanks.RemoveRange(_context.Tanks.Where(predicate));
            _context.SaveChanges();

        }
    }
}