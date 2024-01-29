using Microsoft.AspNetCore.Mvc;
using HotelWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        [HttpPost("cliente")]
        public void PostNovoCliente(Cliente cliente)
        {
            using (var _context = new HotelContext())
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
        }

        [HttpPost("quarto")]
        public void PostNovoQuarto(Quarto quarto)
        {
            using (var _context = new HotelContext())
            {
                _context.Quartos.Add(quarto);
                _context.SaveChanges();
            }
        }

        [HttpGet("cliente")]
        public IActionResult GetCliente()
        {
            using (var _context = new HotelContext())
            {
                return new ObjectResult(_context.Clientes.ToList());
            }
        }

        [HttpGet("cliente/{id}")]
        public IActionResult GetClienteById(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpGet("filial")]
        public IActionResult GetFilial()
        {
            using (var _context = new HotelContext())
            {
                return new ObjectResult(_context.Filials.ToList());
            }
        }

        [HttpGet("quarto")]
        public IActionResult GetQuarto()
        {
            using (var _context = new HotelContext())
            {
                return new ObjectResult(_context.Quartos.Include(q => q.IdAdaptacaoNavigation)
                                                        //.Include(q => q.IdTipoQuartoNavigation)
                                                        //Include(q => q.IdFilialQuartoNavigation)
                                                        .ToList());
            }
        }
        [HttpGet("quarto/{id}")]
        public IActionResult GetQuartoById(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Quartos.Include(q => q.IdAdaptacaoNavigation)
                                             //.Include(q => q.IdTipoQuartoNavigation)
                                            //.Include(q => q.IdFilialQuartoNavigation)
                                            .FirstOrDefault(q => q.NumQuarto == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpGet("reserva")]
        public IActionResult GetRserva()
        {
            using (var _context = new HotelContext())
            {
                return new ObjectResult(_context.Reservas.ToList());
            }
        }

        [HttpPut("cliente/{id}")]
        public IActionResult PutCliente(int id,[FromBody] Cliente cliente)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Clientes.FirstOrDefault(t => t.IdCliente == id);
                if(item == null)
                {
                    return NotFound(); 
                }
                _context.Entry(item).CurrentValues.SetValues(cliente);
                _context.SaveChanges();
                return new ObjectResult(item);
            }
        }

        [HttpPut("quarto/{id}")]
        public IActionResult PutQuarto(int id,[FromBody] Quarto quarto)
        {
            using (var _context = new HotelContext())
            {

                var item = _context.Quartos.FirstOrDefault(t => t.NumQuarto == id);
                
                if(item == null)
                {
                    return NotFound(); 
                }
                _context.Entry(item).CurrentValues.SetValues(quarto);
                _context.SaveChanges();
                return new ObjectResult(item);
            }
        }

        [HttpDelete("cliente/{id}")]
        public IActionResult DeleteCliente(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Clientes.FirstOrDefault(t => t.IdCliente == id);
                if(item == null)
                {
                    return NotFound(); 
                }
                _context.Clientes.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("quarto/{id}")]
        public IActionResult DeleteQuarto(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Quartos.FirstOrDefault(q => q.NumQuarto == id);
                if(item == null)
                {
                    return NotFound(); 

                }
                _context.Quartos.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}