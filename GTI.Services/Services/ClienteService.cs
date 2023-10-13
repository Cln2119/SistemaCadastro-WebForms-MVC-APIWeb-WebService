using GTI.Domain.Entity;
using GTI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Services.Services
{
    public class ClienteService : IClienteService
    {
        private IRepository<ClienteEntity> _repository;   

        public ClienteService(IRepository<ClienteEntity> repository)
        {
            _repository = repository;           
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ClienteEntity> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ClienteEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }    

        public async Task<ClienteEntity> Post(ClienteEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<ClienteEntity> Put(ClienteEntity user)
        {
            return await _repository.UpdateAsync(user);
        }

    }
}
