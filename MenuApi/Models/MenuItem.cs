﻿namespace MenuApi.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }         
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }  
    }
}
