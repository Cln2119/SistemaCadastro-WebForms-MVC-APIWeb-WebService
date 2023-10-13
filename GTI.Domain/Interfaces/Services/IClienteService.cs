using GTI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ClienteEntity> Get(int id);   
        Task<IEnumerable<ClienteEntity>> GetAll();  
        Task<ClienteEntity> Post(ClienteEntity user);
        Task<ClienteEntity> Put(ClienteEntity user);
        Task<bool> Delete(int id);    
    }
}
