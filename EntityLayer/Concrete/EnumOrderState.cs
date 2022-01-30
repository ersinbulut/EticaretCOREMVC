using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public enum EnumOrderState
    {
        [Display(Name = "Onay Bekleniyor")]
        Bekleniyor,
        [Display(Name = "Tamamlandı")]
        Tamamlandı,
        [Display(Name = "Paketlendi")]
        Paketlendi,
        [Display(Name = "Kargolandı")]
        Kargolandı
    }
}
