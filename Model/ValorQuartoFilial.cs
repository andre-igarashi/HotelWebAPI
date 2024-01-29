using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class ValorQuartoFilial
{
    public int IdValorQuartoFilial { get; set; }

    public int? IdFilial { get; set; }

    public int? CodTipoQuarto { get; set; }

    public decimal? DiariaQuartoFilial { get; set; }

    public virtual TipoQuarto? CodTipoQuartoNavigation { get; set; }

    public virtual Filial? IdFilialNavigation { get; set; }
}
