using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int IdClienteReserva { get; set; }

    public int IdFuncionarioReserva { get; set; }

    public bool? AdicionarColchao { get; set; }

    public virtual Cliente IdClienteReservaNavigation { get; set; } = null!;

    public virtual Funcionario IdFuncionarioReservaNavigation { get; set; } = null!;

    public virtual ICollection<ReservaQuarto> ReservaQuartos { get; set; } = new List<ReservaQuarto>();
}
