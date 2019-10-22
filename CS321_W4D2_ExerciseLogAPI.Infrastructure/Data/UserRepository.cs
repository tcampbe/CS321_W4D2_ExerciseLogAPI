using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User newUser)
        {
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        public User Get(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();

        }

        public User Update(User updatedUser)
        {
            // get the user object in the current list with this id 
            var currentUser = this.Get(updatedUser.Id);


            // return null if usere to update isn't found
            if (currentUser == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed user into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry<User>(currentUser)
                .CurrentValues
                .SetValues(updatedUser);

            // update the user and save
            _dbContext.Users.Update(currentUser);
            _dbContext.SaveChanges();
            return currentUser;
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}