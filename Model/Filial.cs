using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class Filial
{
    public int IdFilial { get; set; }

    public string NomeFilial { get; set; } = null!;

    public string? EnderecoFilial { get; set; }

    public int? QuartosSolteiro { get; set; }

    public int? QuartosCasal { get; set; }

    public int? QuartosFamilia { get; set; }

    public int? QuartosPresidencial { get; set; }

    public int? Estrelas { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<ItemConsumivelFilial> ItemConsumivelFilials { get; set; } = new List<ItemConsumivelFilial>();

    public virtual ICollection<Quarto> Quartos { get; set; } = new List<Quarto>();

    public virtual ICollection<ValorQuartoFilial> ValorQuartoFilials { get; set; } = new List<ValorQuartoFilial>();
}
