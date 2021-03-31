using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandoWebService.Data.Models
{
    [Table("EliteRefs")]
    public class EliteRef
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int SomeInt { get; set; }
        public double SomeDouble { get; set; }
        public DateTime SomeDateTime { get; set; }
        public ICollection<EliteData> SomeElites { get; set; } = new List<EliteData>();
        public ICollection<EliteRef> OtherRefs { get; set; } = new List<EliteRef>();

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}