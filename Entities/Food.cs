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

        public int kalori { get; set; }

        public int protein_gr { get; set; }
        public int yağ_gr { get; set; }
        public int karbonhidrat_gr { get; set; }
        public int sodyum_gr { get; set; }
        public int potasyum_gr { get; set; }
        public int kalsiyum_gr { get; set; }
        public int lif_gr { get; set; }
        public int kollestrol_gr { get; set; }
        public int gün_bozulma_tarihi { get; set; }
        //ref
        public My_Food My_Food { get; set; }
    }
}
