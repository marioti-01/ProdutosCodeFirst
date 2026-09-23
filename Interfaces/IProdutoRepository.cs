using ProdutosCodeFirst.Models;

namespace ProdutosCodeFirst.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetAllAsync();
    Task<Produto?> GetByIdAsync(int id);
    Task<Produto> AddAsync(Produto produto);
    Task<bool> UpdateAsync(Produto produto);
    Task<bool> DeleteAsync(int id);
}