using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class Contum
{
    public int CodConta { get; set; }

    public int IdNotaConta { get; set; }

    public virtual NotaFiscal IdNotaContaNavigation { get; set; } = null!;

    public virtual ICollection<ItemContum> ItemConta { get; set; } = new List<ItemContum>();

    public virtual ICollection<ItemLavanderiaContum> ItemLavanderiaConta { get; set; } = new List<ItemLavanderiaContum>();
}
