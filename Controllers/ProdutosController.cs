using Microsoft.AspNetCore.Mvc;
using ProdutosCodeFirst.Models;
using ProdutosCodeFirst.Services;

namespace ProdutosCodeFirst.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutosController(ProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetById(int id)
    {
        var produto = await _service.GetByIdAsync(id);

        if (produto is null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> Create(Produto produto)
    {
        var created = await _service.AddAsync(produto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Produto produto)
    {
        if (id != produto.Id)
            return BadRequest("O ID da URL não corresponde ao ID do produto.");

        var updated = await _service.UpdateAsync(produto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}