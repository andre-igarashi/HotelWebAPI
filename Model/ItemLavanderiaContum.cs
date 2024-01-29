using System;
using System.Collections.Generic;

namespace HotelWebAPI.Model;

public partial class ItemLavanderiaContum
{
    public int CodItemLavanderia { get; set; }

    public string? Servico { get; set; }

    public int? CodConta { get; set; }

    public int? IdServicoLavanderia { get; set; }

    public int Quantidade { get; set; }

    public virtual Contum? CodContaNavigation { get; set; }

    public virtual ServicoLavanderium? IdServicoLavanderiaNavigation { get; set; }
}
