using System;
using System.Collections.Generic;

namespace DAL_Library
{
    public interface IMemberRepository
    {
        List<Member> AllMember();

        void AddMember(Member member);
        bool UpdateMember(Member member);
        bool DeleteMember(int id);
        List<Member> SearchMembers(string searchTerm);

        Member? GetMemberById(int id);
        Member? GetMemberByMembershipCode(string membershipCode); 
        bool IsMembershipCodeUnique(string membershipCode, int id = 0);
        bool IsNationalCodeUnique(string nationalCode, int id = 0);
    }
}
