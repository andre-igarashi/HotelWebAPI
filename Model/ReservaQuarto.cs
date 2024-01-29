using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class ReservaQuarto
{
    public int IdReservaQuarto { get; set; }

    public DateOnly DataCheckIn { get; set; }

    public DateOnly DataCheckOut { get; set; }

    public bool? Cancelada { get; set; }

    public int? IdReserva { get; set; }

    public int? IdQuarto { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }
}
