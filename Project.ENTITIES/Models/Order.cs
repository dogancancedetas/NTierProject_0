﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order: BaseEntity
    {
        public string ShippedAddress { get; set; }
        public decimal TotalPrice { get; set; }

        //Sipariş işlemlerinin içerisindeki bilgileri daha rahat yakalamak adına açtığımız property'lerden bir tanesi TotalPrice'tır. Yalnız burada çok dikkatli olmanız gerekir gerçekten size hız kazandıracak bir durum varsa bu bilgileri ek olarak buraya almanız gerekir. Aynı zamanda bu durum abartılmamalıdır. İlgili yapının tüm verileri asla bu sınıfa komple koyulmamalıdır. Sadece spesifik parçalar alınmalıdır.
       
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? AppUserID { get; set; }

        //Relational Properties

        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
