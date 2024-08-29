using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly ContaService _contaService;

    public ContaController(ContaService contaService)
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
    var contaId = _contaService.AddConta(
        contaDto.Tipo,
        contaDto.CorrentistaId,
        contaDto.Numero,
        contaDto.Agencia,
        contaDto.SaldoInicial,
        contaDto.Limite);

    return CreatedAtAction(nameof(GetContaById), new { id = contaId }, contaDto);
}

    [HttpPut("{id}")]
    public IActionResult UpdateConta(long id, [FromBody] Conta conta)
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
    public IActionResult Depositar(int id, [FromBody] double valor)
    {
        try
        {
            _contaService.Depositar(id, valor);
            return NoContent();
        }
        catch (Exception ex)
        { 
            return BadRequest(new { message = ex.Message });
        }
        
    }

    [HttpPost("{id}/sacar")]
    public IActionResult Sacar(int id, [FromBody] double valor)
    {
        try
        {
            _contaService.Sacar(id, valor);
            return NoContent(); // Retorna 204 No Content se o saque for bem-sucedido
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message }); // Retorna 400 Bad Request com a mensagem de erro
        }
    }

    [HttpPost("{id}/aplicar-juros-poupanca")]
    public IActionResult AplicarJurosContaPoupanca(int id, [FromBody] double taxaJuros)
    {
        try
        {
            _contaService.AplicarJurosContaPoupanca(id, taxaJuros);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        
    }

    [HttpPost("{id}/aplicar-juros-corrente")]
    public IActionResult AplicarJurosContaCorrente(int id, [FromBody] double taxaJuros)
    {
        try
        {
            _contaService.AplicarJurosContaCorrente(id, taxaJuros);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        
    }
}
