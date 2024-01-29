using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class Funcao
{
    public int CodFuncao { get; set; }

    public string Funcao1 { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
