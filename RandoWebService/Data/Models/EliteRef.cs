﻿using System;
using System.Collections.Generic;

namespace RandoWebService.Data.Models
{
    public class EliteRef
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int SomeInt { get; set; }
        public double SomeDouble { get; set; }
        public DateTime SomeDateTime { get; set; }
        public IEnumerable<EliteData> SomeElites { get; set; }
        public IEnumerable<EliteRef> OtherRefs { get; set; }
    }
}