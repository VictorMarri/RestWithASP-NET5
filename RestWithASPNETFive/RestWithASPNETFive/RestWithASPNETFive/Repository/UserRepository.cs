using RestWithASPNETFive.Data.VO;
using RestWithASPNETFive.Models;
using RestWithASPNETFive.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            //Encriptar
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName.Equals(user.UserName) && (u.Password.Equals(user.Password))));
        }

        public User ResfreshUserInfo(User user)
        {
            //Se nao encontrar ninguem no banco com o msm ID passado em parametro, retorna nulo
            if (!_context.Users.Any(u => u.Id.Equals(user.Id)));
            {
                return null;
            }

            //Se ele encontrar alguem que tenha o mesmo ID, armazena em result
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

            //Se result for diferente de nulo, ou seja, existir, a gente atualiza os dados do usuario
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

                return result;
            }

            return result;

        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        
    }
}
