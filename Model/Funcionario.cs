using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public string Nome { get; set; } = null!;

    public int IdFuncao { get; set; }

    public DateOnly DataNascimento { get; set; }

    public string? Endereco { get; set; }

    public string Telefone { get; set; } = null!;

    public int? IdFilialFuncionario { get; set; }

    public virtual Filial? IdFilialFuncionarioNavigation { get; set; }

    public virtual Funcao IdFuncaoNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
