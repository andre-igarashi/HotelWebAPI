using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class NotaFiscal
{
    public int NumNota { get; set; }

    public decimal? ValorTotal { get; set; }

    public int? CodTipoPagamento { get; set; }

    public virtual FormaPagamento? CodTipoPagamentoNavigation { get; set; }

    public virtual ICollection<Contum> Conta { get; set; } = new List<Contum>();
}
