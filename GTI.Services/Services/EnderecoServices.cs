using GTI.Domain.Entity;
using GTI.Domain.Interfaces.Services;

namespace GTI.Services.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        private IRepository<EnderecoClienteEntity> _repository;

        public EnderecoServices(IRepository<EnderecoClienteEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<EnderecoClienteEntity> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<EnderecoClienteEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<EnderecoClienteEntity> Post(EnderecoClienteEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<EnderecoClienteEntity> Put(EnderecoClienteEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
