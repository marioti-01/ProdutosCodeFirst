using ProdutosCodeFirst.Interfaces;
using ProdutosCodeFirst.Models;

namespace ProdutosCodeFirst.Services;

public class ProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Produto>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Produto?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<Produto> AddAsync(Produto produto)
    {
        return _repository.AddAsync(produto);
    }

    public Task<bool> UpdateAsync(Produto produto)
    {
        return _repository.UpdateAsync(produto);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}