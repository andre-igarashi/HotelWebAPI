using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class ItemConsumivelFilial
{
    public int CodItem { get; set; }

    public string Nome { get; set; } = null!;

    public decimal ValorUnitario { get; set; }

    public int? IdFilialItem { get; set; }

    public virtual Filial? IdFilialItemNavigation { get; set; }

    public virtual ICollection<ItemContum> ItemConta { get; set; } = new List<ItemContum>();
}
