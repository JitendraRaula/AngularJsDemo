﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsDemo
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}