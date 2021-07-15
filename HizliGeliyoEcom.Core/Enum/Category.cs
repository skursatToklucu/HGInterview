using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HizliGeliyoEcom.Core.Enum
{
    public enum Category
    {
        [Display(Name = "Erkek Giyim")]
        menClothing = 1,

        [Display(Name = "Kadın Giyim")]
        womenClothing = 2,

        [Display(Name = "Takı")]
        jewelery = 3,

        [Display(Name = "Elektronik")]
        electronic = 4
    }
}
