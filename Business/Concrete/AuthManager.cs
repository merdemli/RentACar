using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {

            User user = _userService.GetByEmail(userForLoginDto.Email);

            if (user == null)
                return new ErrorDataResult<User>("böle biri yok kardeş yürü");

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                return new ErrorDataResult<User>("şifre yanlış");

            else
                return new SuccessDataResult<User>();

        }
       
        public void CustomerRegister(CustomerRegisterDto customerRegisterDto)
        {
            throw new NotImplementedException();
        }
    }
}
