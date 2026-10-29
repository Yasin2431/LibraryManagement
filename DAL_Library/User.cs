using System;
using System.ComponentModel.DataAnnotations;
using BLL_Library; 

namespace DAL_Library
{
    public class User
    {
        
        public User( string firstName, string lastName, string nationalCode, string phoneNumber, byte[]? photo = null)
        {
           
           
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            PhoneNumber = phoneNumber;
            Photo = photo;
        }

       

        

        public int Id { get; set; }

       
        [RegularExpression(@"^\d{4}$",ErrorMessage ="کد عضویت نباید بیشتر از 4 کاراکتر باشد.")]
        public string MembershipCode { get; set; }

        
        [Required(ErrorMessage = "نام کاربر الزامی است.")]
        [StringLength(50, ErrorMessage = "نام نمی‌تواند بیشتر از ۵۰ کاراکتر باشد.")]
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "نام باید فقط شامل حروف فارسی باشد.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی الزامی است.")]
        [StringLength(50, ErrorMessage = "نام خانوادگی نمی‌تواند بیشتر از ۵۰ کاراکتر باشد.")]
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "نام خانوادگی باید فقط شامل حروف فارسی باشد.")]
        public string LastName { get; set; }

      
        public string FullName => $"{FirstName} {LastName}".Trim();

        
        [Required(ErrorMessage = "کد ملی الزامی است.")]
        [NationalCodeAttribute]
        public string NationalCode { get; set; }

        
        [Required(ErrorMessage = "شماره موبایل الزامی است.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل نامعتبر است (مثال: 09123456789).")]
        public string PhoneNumber { get; set; }

        
        public DateTime MembershipDate { get; set; } = DateTime.Now;

        
        [FileSizeAttribute(2, ErrorMessage = "حجم عکس کاربر نباید بیشتر از ۲ مگابایت باشد.")]
        public byte[]? Photo { get; set; }
    }
}
