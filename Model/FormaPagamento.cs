using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class FormaPagamento
{
    public int CodTipoPagamento { get; set; }

    public string TipoPagamento { get; set; } = null!;

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}
