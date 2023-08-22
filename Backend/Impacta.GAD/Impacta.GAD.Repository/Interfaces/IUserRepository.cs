using Impacta.GAD.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Interfaces
{
    public interface IUserRepository : IGADRepository
    {
        #region User
        Task<List<User>> GetTodosUsers();
        Task<User> GetUserById(long userId);
        Task<User> GetUserByUserNameAsync(string userName);

        #endregion

    }
}
