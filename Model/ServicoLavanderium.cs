using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class ServicoLavanderium
{
    public int IdServicoLavanderia { get; set; }

    public string NomeServico { get; set; } = null!;

    public decimal Preco { get; set; }

    public virtual ICollection<ItemLavanderiaContum> ItemLavanderiaConta { get; set; } = new List<ItemLavanderiaContum>();
}
