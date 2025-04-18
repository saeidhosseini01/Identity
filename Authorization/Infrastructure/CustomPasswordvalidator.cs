using Authorization.Models;
using Microsoft.AspNetCore.Identity;

namespace Authorization.Infrastructure
{


    public class CustomPasswordvalidator2 : PasswordValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);

            List<IdentityError> errorList = result.Succeeded
                ? new List<IdentityError>()
                : result.Errors.ToList();

            if (!string.IsNullOrEmpty(password))
            {
                if (password.Contains("1234"))
                {
                    errorList.Add(new IdentityError
                    {
                        Code = "SimplePassword",
                        Description = "رمز عبور نباید شامل 1234 باشد."
                    });
                }

                if (password.ToLower().Contains(user.UserName.ToLower()))
                {
                    errorList.Add(new IdentityError
                    {
                        Code = "UserNameInPassword",
                        Description = "رمز عبور نباید شامل نام کاربری باشد."
                    });
                }
            }

            return errorList.Count == 0
                ? IdentityResult.Success
                : IdentityResult.Failed(errorList.ToArray());
         }
    }


    public class CustomPasswordvalidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
           List<IdentityError> errorList = new List<IdentityError>();
            if (password.Contains("1234"))
            {
                errorList.Add(new IdentityError{
                    Code = "add",
                    Description = "add nabashad"
                });

            }
            if (password.Contains(user.UserName.ToLower()))
            {
                errorList.Add(new IdentityError{
                    Code = "username",
                    Description = "can not use username iv=n Password"
                });
            }
            return Task.FromResult(errorList.Count == 0 ? IdentityResult.Success 
                : IdentityResult.Failed(errorList.ToArray()));
        }
    }

    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            if (user.Email.ToLower().EndsWith("@saeed.com"))
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "only saeed.com email address are allowsd"
                }));
            }


        }
    }
}
