using DAL_Library;
using LibraryManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL_Library
{
    public class BLL_UserService
    {
        private readonly IUserRepository _userrepository;
        public BLL_UserService(IUserRepository repository)
        {
            _userrepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public BLL_UserService(string type, string databaseType)
        {
            if (databaseType == "SQL" && type == "کاربر جدید")
                _userrepository = new SqlUserRepository();
        }
        public List<ValidationResult> Validation(user user)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(user);
            bool isvalid = Validator.TryValidateObject(user, context, results, true);
            return results;
            
        }
        public List<user> GetUsers()
        {
            return _userrepository.GetAllUsers();
        }
        public void AddUser(user user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _userrepository.AddUser(user);
        }
        public bool UpdateUser(user user) 
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return _userrepository.UpdateUser(user);
        }
        public bool DeleteUser(int id) 
        {
            if (id <= 0) { return false; }
            return _userrepository.DeleteUser(id);
        }
        public user GetUserById(int id)
        {
            if (id <= 0) return null;
            return _userrepository.GetUserById(id);
        }
        public user GetUserByMembershipCode(string membershipCode) 
        {
            return _userrepository.GetUserByMembershipCode(membershipCode);
        }
        public bool IsNationalCodeUnique(string nationalCode, int id = 0)
        {
            if (string.IsNullOrWhiteSpace(nationalCode) || id < 0)
                return false;

            return _userrepository.IsNationalCodeUnique(nationalCode, id);
        }

        public bool IsMembershipCodeUnique(string membershipCode, int id = 0)
        {
            if (string.IsNullOrWhiteSpace(membershipCode) || id < 0)
                return false;

            return _userrepository.IsMembershipCodeUnique(membershipCode, id);
        }


    }
}
