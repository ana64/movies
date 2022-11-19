using Movies.DataAccess.Exceptions;
using Movies.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Movies.DataAccess.Extensions
{
    public  static class DbSetExtensions
    {
        public static void Deactivate(this AppDbContext context, Entity entity)
        {
            entity.IsActive = false;
            context.Entry(entity).State = EntityState.Modified;
        }

        public static void Deactivate<T>(this  AppDbContext context, int id)
            where T : Entity
        {
            var itemToDeactivate = context.Set<T>().Find(id);

            if (itemToDeactivate == null)
            {
                throw new EntityNotFoundException();
            }

            itemToDeactivate.IsActive = false;
        }

        public static void Deactivate<T>(this  AppDbContext context, IEnumerable<int> ids)
            where T : Entity
        {
            var toDeactivate = context.Set<T>().Where(x => ids.Contains(x.Id));

            foreach (var d in toDeactivate)
            {
                d.IsActive = false;
            }

        }
    }
}
