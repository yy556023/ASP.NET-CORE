using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab_View_Helper.Models {
    public class Product {
        public int Id;

        [Required(ErrorMessage = "產品名稱是必填資料")]
        [DisplayName("產品名稱")]
        public string Name { get; set; }

        [DisplayName("價格")]
        [Range(1, int.MaxValue, ErrorMessage = "價格請大於零")]
        public int Price { get; set; }
    }
}
