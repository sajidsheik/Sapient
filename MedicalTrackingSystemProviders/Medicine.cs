using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalTrackingSystemProviders
{
    public class Medicine
    {
        [Key]
        public string MedicineName { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirayDate { get; set; }

        public string Notes {get; set;}
    }
}
