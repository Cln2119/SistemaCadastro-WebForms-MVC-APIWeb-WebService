using GTI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Domain.Interfaces.Services
{
    public interface IEnderecoServices
    {
        Task<EnderecoClienteEntity> Get(int id);
        Task<IEnumerable<EnderecoClienteEntity>> GetAll();
        Task<EnderecoClienteEntity> Post(EnderecoClienteEntity user);
        Task<EnderecoClienteEntity> Put(EnderecoClienteEntity user);
        Task<bool> Delete(int id);
    }
}
