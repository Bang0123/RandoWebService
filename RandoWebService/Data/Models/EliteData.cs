using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandoWebService.Data.Models
{
    [Table("EliteDatas")]
    public class EliteData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int SomeInt { get; set; }
        public double SomeDouble { get; set; }
        public DateTime SomeDateTime { get; set; }
        public EliteRef SomeRef { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
