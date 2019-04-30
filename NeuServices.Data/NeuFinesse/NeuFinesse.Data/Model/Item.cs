using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuFinesse.Data.Model
{
    public enum Types
    {
        Goods,
        Service
    }
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int InterestId { get; set; }
        [ForeignKey("InterestId")]
        public Interest Interest { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ItemImage { get; set; }
        public decimal Weight { get; set; }
        public Types Type { get; set; }
    }
}
