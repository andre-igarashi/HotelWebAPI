using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nome { get; set; } = null!;

    public string? Endereco { get; set; }

    public string? Nacionalidade { get; set; }

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
