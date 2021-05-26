﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}