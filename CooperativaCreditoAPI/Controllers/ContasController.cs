using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private readonly ContaService _contaService;

    public ContasController(ContaService contaService)
    {
        _contaService = contaService;
    }

    [HttpGet("{id}")]
    public IActionResult GetContaById(int id)
    {
        var conta = _contaService.GetContaById(id);
        if (conta == null) return NotFound();

        return Ok(conta);
    }

    [HttpGet]
    public IActionResult GetAllContas()
    {
        var contas = _contaService.GetAllContas();
        return Ok(contas);
    }

    [HttpPost]
public IActionResult AddConta([FromBody] ContaDto contaDto)
{
    _contaService.AddConta(
        contaDto.TipoConta,
        contaDto.Correntista,
        contaDto.Numero,
        contaDto.Agencia,
        contaDto.SaldoInicial,
        contaDto.Limite);

    return CreatedAtAction(nameof(GetContaById), new { id = contaDto.Numero }, contaDto);
}

    [HttpPut("{id}")]
    public IActionResult UpdateConta(int id, [FromBody] Conta conta)
    {
        if (id != conta.Id) return BadRequest();

        _contaService.UpdateConta(conta);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteConta(int id)
    {
        _contaService.DeleteConta(id);
        return NoContent();
    }

    [HttpPost("{id}/depositar")]
    public IActionResult Depositar(int id, [FromBody] decimal valor)
    {
        _contaService.Depositar(id, valor);
        return NoContent();
    }

    [HttpPost("{id}/sacar")]
    public IActionResult Sacar(int id, [FromBody] decimal valor)
    {
        _contaService.Sacar(id, valor);
        return NoContent();
    }

    [HttpPost("{id}/aplicar-juros-poupanca")]
    public IActionResult AplicarJurosContaPoupanca(int id, [FromBody] decimal taxaJuros)
    {
        _contaService.AplicarJurosContaPoupanca(id, taxaJuros);
        return NoContent();
    }

    [HttpPost("{id}/aplicar-juros-corrente")]
    public IActionResult AplicarJurosContaCorrente(int id, [FromBody] decimal taxaJuros)
    {
        _contaService.AplicarJurosContaCorrente(id, taxaJuros);
        return NoContent();
    }
}
