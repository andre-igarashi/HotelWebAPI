using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class Quarto
{
    public int NumQuarto { get; set; }

    public int IdTipoQuarto { get; set; }

    public int? IdAdaptacao { get; set; }

    public int? IdFilialQuarto { get; set; }

    public virtual AdaptacaoQuarto? IdAdaptacaoNavigation { get; set; }

    public virtual Filial? IdFilialQuartoNavigation { get; set; }

    public virtual TipoQuarto? IdTipoQuartoNavigation { get; set; }
}
