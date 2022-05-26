using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Food
    {
        public int id { get; set; }
        public string yemek_ismi { get; set; }

        public int protein_yüzde { get; set; }
        public int yağ_yüzde { get; set; }
        public int karbonhidrat_yüzde { get; set; }

        public double kalori { get; set; }

        public double protein_gr { get; set; }
        public double yağ_gr { get; set; }
        public double karbonhidrat_gr { get; set; }
        public double sodyum_gr { get; set; }
        public double potasyum_gr { get; set; }
        public double kalsiyum_gr { get; set; }
        public double lif_gr { get; set; }
        public double kollestrol_gr { get; set; }
        public int gün_bozulma_tarihi { get; set; }
        //ref
        public My_Food My_Food { get; set; }
    }
}
