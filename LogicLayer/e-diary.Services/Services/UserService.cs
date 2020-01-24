using e_diary.Database;
using e_diary.Database.Models;
using e_diary.Service.Interfaces;
using e_diary.ViewModels.User;
using e_diary.ViewModels.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_diary.Service.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<VMUserListItem> GetAll(VMGetUserListRequest vmrequest)
        {
            var users = _context.Users.Where(x => x.IsActive == true)
               .Select(x => new VMUserListItem
               {
                   UserId = x.UserId,
                   Email = x.Email,
                   Password = x.Password,
                   FirstName = x.FirstName,
                   LastName = x.LastName
               }).ToList();

            return users;
        }

        public VMUserDetails Get(VMGetUserDetailsRequest vmrequest)
        {
            var user = _context.Users
               .Where(x => x.UserId == vmrequest.UserId)
               .Select(x => new VMUserDetails
               {
                   UserId = x.UserId,
                   Email = x.Email,
                   Password = x.Password,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
               }).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("User could not be found.");
            }
            else return user;
        }

        public VMUserDetails Create(VMCreateUserRequest vmrequest)
        {
            //using (var transaction = _context.Database.BeginTransaction())
            //{
            //    try
            //    {
            var newUser = new DBUser
            {
                Email = vmrequest.Email,
                Password = vmrequest.Password,
                FirstName = vmrequest.FirstName,
                LastName = vmrequest.LastName,
                IsActive = true
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var user = new VMUserDetails
            {
                UserId = newUser.UserId,
                Email = newUser.Email,
                Password = newUser.Password,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName
            };

            //transaction.Commit();
            return user;
            //}
            //catch (Exception ex)
            //{
            //    transaction.Rollback();
            //    throw ex;
            //}
            //}
        }

        public bool Remove(VMRemoveUserRequest vmrequest)
        {
            var user = _context.Users
                .Where(x => x.UserId == vmrequest.UserId)
                .FirstOrDefault();

            if (user != null)
            {
                user.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public VMUserDetails Update(VMUpdateUserRequest vmrequest)
        {
            var dbUser = _context.Users
                 .Where(m => m.UserId == vmrequest.UserId)
                 .FirstOrDefault();

            if (dbUser == null)
            {
                throw new Exception("User could not be found.");
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    dbUser.LastName = vmrequest.LastName;
                    dbUser.FirstName = vmrequest.FirstName;
                    dbUser.Email = vmrequest.Email;
                    dbUser.Password = vmrequest.Password;
                    _context.SaveChanges();

                    var user = new VMUserDetails
                    {
                        UserId = dbUser.UserId,
                        LastName = dbUser.LastName,
                        FirstName = dbUser.FirstName,
                        Password = dbUser.Password,
                        Email = dbUser.Email,
                    };

                    transaction.Commit();
                    return user;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}