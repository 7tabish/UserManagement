using Microsoft.EntityFrameworkCore;
using OA.Data;
using System.Collections.Generic;

namespace OA.Repository
{
    public class UserRepository<T> : IUserRepository<T> where T: UserModel
    {
        private readonly ApplicationDBContext context;
        public DbSet<T> entity;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDBContext context)
        {
            this.context = context;
            entity = context.Set<T>();
        }
            public void AddUser(T user)
            {
                entity.Add(user);
                context.SaveChanges();
            }
        public bool DeleteUser(T user)
        {
            try
            {
                entity.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex) { throw; }
            return false;
            
        }
        public T GetUserById(int userID)
        {
            return entity.Where(o => o.ID == userID).FirstOrDefault();
        }
        public List<T> GetUsers()
        {
            return entity.ToList();
        }

        public bool UpdateUser(T user)
        {
            Console.WriteLine("in updated user");
            try
            {
                var existingEntity = context.Set<T>().Local.FirstOrDefault(e => e.ID == user.ID);

                if (existingEntity != null)
                {
                    context.Entry(existingEntity).State = EntityState.Detached;
                }

                context.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw; }
            return false;
        }
    }
}
