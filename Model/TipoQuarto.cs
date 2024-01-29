using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class TipoQuarto
{
    public int CodTipoQuarto { get; set; }

    public string TipoQuarto1 { get; set; } = null!;

    public string? Descricao { get; set; }

    public int CapacidadeMaxima { get; set; }

    public int CapacidadeOpcional { get; set; }

    public virtual ICollection<Quarto> Quartos { get; set; } = new List<Quarto>();

    public virtual ICollection<ValorQuartoFilial> ValorQuartoFilials { get; set; } = new List<ValorQuartoFilial>();
}
