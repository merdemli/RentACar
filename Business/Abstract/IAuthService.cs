using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        void CustomerRegister(CustomerRegisterDto customerRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
    }
}
