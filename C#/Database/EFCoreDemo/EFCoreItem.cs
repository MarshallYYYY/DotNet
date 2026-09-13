using System.ComponentModel.DataAnnotations;

namespace EFCoreDemo
{
    public class EFCoreItem
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
    }
}
