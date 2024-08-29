using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CorrentistasController : ControllerBase
{
    private readonly CorrentistaService _correntistaService;

    public CorrentistasController(CorrentistaService correntistaService)
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
    public IActionResult AddCorrentista([FromBody] Correntista correntista)
    {
        _correntistaService.AddCorrentista(correntista);
        return CreatedAtAction(nameof(GetCorrentistaById), new { id = correntista.Id }, correntista);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCorrentista(int id, [FromBody] Correntista correntista)
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
