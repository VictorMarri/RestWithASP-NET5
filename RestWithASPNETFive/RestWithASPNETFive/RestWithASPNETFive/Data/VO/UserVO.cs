using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Data.VO
{
    /// <summary>
    /// Classe que faz a representação da entidade base User para VO
    /// </summary>
    public class UserVO
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
