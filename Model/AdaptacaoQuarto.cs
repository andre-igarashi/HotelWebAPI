using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class AdaptacaoQuarto
{
    public int CodAdaptacao { get; set; }

    public string TipoAdaptacao { get; set; } = null!;

    public virtual ICollection<Quarto> Quartos { get; set; } = new List<Quarto>();
}
