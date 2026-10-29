using System;
using System.Collections.Generic;

namespace DAL_Library
{
    public interface IUserRepository
    {
        List<user> GetAllUsers();
        void AddUser(user user);
        bool UpdateUser(user user);
        bool DeleteUser(int id);
        user? GetUserById(int id);
        user? GetUserByMembershipCode(string membershipCode); 
        bool IsMembershipCodeUnique(string membershipCode, int id = 0);
        bool IsNationalCodeUnique(string nationalCode, int id = 0);
    }
}
