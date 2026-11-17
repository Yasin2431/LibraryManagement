using DAL_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BLL_Library
{
    public class BLL_UserService
    {
        private readonly IMemberRepository _userrepository;

        public BLL_UserService(IMemberRepository repository)
        {
            _userrepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public BLL_UserService(string type, string database)
        {
            if (database == "SQL" & type == "کاربر جدید")
            {
                _userrepository = new SqlUserRepository();
            }
            else 
            {
                throw new NotSupportedException("این قسمت در حال توسعه است");
            }
          
        }

        public List<ValidationResult> Validation(Member member)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(member);
            Validator.TryValidateObject(member, context, results, true);
            return results;
        }

        public OperationResultMember<List<Member>> GetUsers()
        {
            var members = _userrepository.AllMember();
            return OperationResultMember<List<Member>>.Ok(members);
        }

        public OperationResultMember AddUser(Member member)
        {
            if (member == null)
                return OperationResultMember.Fail("اطلاعات کاربر نامعتبر است.");

            var validationResults = Validation(member);
            if (validationResults.Any())
                return OperationResultMember.Fail(validationResults.First().ErrorMessage ?? "اطلاعات فرم ناقص است.");

            if (!IsNationalCodeUnique(member.NationalCode))
                return OperationResultMember.Fail("این کد ملی قبلاً ثبت شده است.");

            if (!IsMembershipCodeUnique(member.MembershipCode))
                return OperationResultMember.Fail("کد عضویت تکراری است.");

            _userrepository.AddMember(member);
            return OperationResultMember.Ok("کاربر با موفقیت ثبت شد.");
        }

        public OperationResultMember UpdateUser(Member member)
        {
            if (member == null)
                return OperationResultMember.Fail("اطلاعات کاربر نامعتبر است.");

            var validationResults = Validation(member);
            if (validationResults.Any())
                return OperationResultMember.Fail(validationResults.First().ErrorMessage ?? "اطلاعات فرم ناقص است.");

            if (!IsNationalCodeUnique(member.NationalCode, member.Id))
                return OperationResultMember.Fail("این کد ملی متعلق به کاربر دیگری است.");

            if (!IsMembershipCodeUnique(member.MembershipCode, member.Id))
                return OperationResultMember.Fail("کد عضویت متعلق به کاربر دیگری است.");

            bool updated = _userrepository.UpdateMember(member);
            if (!updated)
                return OperationResultMember.Fail("خطا در ویرایش اطلاعات کاربر.");

            return OperationResultMember.Ok("کاربر با موفقیت ویرایش شد.");
        }

        public OperationResultMember DeleteUser(int id)
        {
            if (id <= 0)
                return OperationResultMember.Fail("شناسه نامعتبر است.");

            bool deleted = _userrepository.DeleteMember(id);
            if (!deleted)
                return OperationResultMember.Fail("کاربر یافت نشد یا حذف انجام نشد.");

            return OperationResultMember.Ok("کاربر با موفقیت حذف شد.");
        }

        public OperationResultMember<Member> GetUserById(int id)
        {
            if (id <= 0)
                return OperationResultMember<Member>.Fail("شناسه نامعتبر است.");

            var member = _userrepository.GetMemberById(id);
            if (member == null)
                return OperationResultMember<Member>.Fail("کاربری با این شناسه یافت نشد.");

            return OperationResultMember<Member>.Ok(member);
        }

        public OperationResultMember<Member> GetUserByMembershipCode(string membershipCode)
        {
            if (string.IsNullOrWhiteSpace(membershipCode))
                return OperationResultMember<Member>.Fail("کد عضویت نامعتبر است.");

            var member = _userrepository.GetMemberByMembershipCode(membershipCode);
            if (member == null)
                return OperationResultMember<Member>.Fail("کاربری با این کد عضویت یافت نشد.");

            return OperationResultMember<Member>.Ok(member);
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
        public OperationResultMember<List<Member>> SearchMembers(string searchTerm)
        {
            try
            {
            if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    var all = _userrepository.AllMember() ?? new List<Member>();
                    return OperationResultMember<List<Member>>.Ok(all);
                }

                var results = _userrepository.SearchMembers(searchTerm.Trim()) ?? new List<Member>();
                return OperationResultMember<List<Member>>.Ok(results);
            }
            catch (Exception ex)
            {
                return OperationResultMember<List<Member>>.Fail($"خطا در انجام جستجو: {ex.Message}");
            }
        }
    }
}
