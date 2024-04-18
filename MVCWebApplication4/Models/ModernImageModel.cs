namespace MVCWebApplication4.Models
{
    public class ModernImageModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string price { get; set; }
        public string Description { get; set; }
        public  IFormFile imagefile { get; set; }
    }
}
