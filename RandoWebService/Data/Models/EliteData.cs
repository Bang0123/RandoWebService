using System;

namespace RandoWebService.Data.Models
{
    public class EliteData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int SomeInt { get; set; }
        public double SomeDouble { get; set; }
        public DateTime SomeDateTime { get; set; }
        public EliteRef SomeRef { get; set; }
    }
}
