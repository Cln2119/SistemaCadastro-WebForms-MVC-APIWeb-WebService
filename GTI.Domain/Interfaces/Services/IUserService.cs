using GTI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> Get(int id);   
        Task<IEnumerable<UserEntity>> GetAll();  
        Task<UserEntity> Post(UserEntity user);
        Task<UserEntity> Put(UserEntity user);
        Task<bool> Delete(int id);    
    }
}
