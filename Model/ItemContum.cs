using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class ItemContum
{
    public int CodItem { get; set; }

    public int CodConta { get; set; }

    public string Item { get; set; } = null!;

    public int Quantidade { get; set; }

    public decimal Valor { get; set; }

    public string? Origem { get; set; }

    public decimal AcrescimoEntrega { get; set; }

    public virtual Contum CodContaNavigation { get; set; } = null!;

    public virtual ItemConsumivelFilial CodItemNavigation { get; set; } = null!;
}
