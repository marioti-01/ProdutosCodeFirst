using Microsoft.EntityFrameworkCore;
using ProdutosCodeFirst.Contexts;
using ProdutosCodeFirst.Interfaces;
using ProdutosCodeFirst.Models;

namespace ProdutosCodeFirst.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ProdutoContext _context;

    public ProdutoRepository(ProdutoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        return await _context.Produtos
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Produto?> GetByIdAsync(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<Produto> AddAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return produto;
    }

    public async Task<bool> UpdateAsync(Produto produto)
    {
        var exists = await _context.Produtos
            .AnyAsync(p => p.Id == produto.Id);

        if (!exists)
            return false;

        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto is null)
            return false;

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return true;
    }
}