using RestWithASPNETFive.Data.VO;
using RestWithASPNETFive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
    }
}
