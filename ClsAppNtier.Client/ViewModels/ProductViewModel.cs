﻿using Entities;

namespace ViewModels;

public class ProductViewModel
{
    public int? Id { get; set; }
    public string? ProductName { get; set; }
    public decimal? Price { get; set; }
    public string? CategoryName { get; set; } 
}
