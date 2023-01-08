using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodsOrderAPI.Models;

[Table("FoodItem")]
public partial class FoodItem
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string ImgSource { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }
}
