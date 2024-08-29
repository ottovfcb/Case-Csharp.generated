using CooperativaCreditoAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CorrentistaController : ControllerBase
{
    private readonly CorrentistaService _correntistaService;

    public CorrentistaController(CorrentistaService correntistaService)
    {
        _correntistaService = correntistaService;
    }

    [HttpGet("{id}")]
    public IActionResult GetCorrentistaById(int id)
    {
        var correntista = _correntistaService.GetCorrentistaById(id);
        if (correntista == null) return NotFound();

        return Ok(correntista);
    }

    [HttpGet]
    public IActionResult GetAllCorrentistas()
    {
        var correntistas = _correntistaService.GetAllCorrentistas();
        return Ok(correntistas);
    }

    [HttpPost]
    public IActionResult AddCorrentista([FromBody] CorrentistaDTO correntistaDTO)
    {
        var correntistaId = _correntistaService.AddCorrentista(
            correntistaDTO.CPF,
            correntistaDTO.Nome,
            correntistaDTO.Endereco,
            correntistaDTO.Profissao         
            );


        return CreatedAtAction(nameof(GetCorrentistaById), new { id = correntistaId }, correntistaDTO);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCorrentista(long id, [FromBody] Correntista correntista)
    {
        if (id != correntista.Id) return BadRequest();

        _correntistaService.UpdateCorrentista(correntista);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCorrentista(int id)
    {
        _correntistaService.DeleteCorrentista(id);
        return NoContent();
    }
}
