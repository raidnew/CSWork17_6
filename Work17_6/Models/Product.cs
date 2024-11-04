using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work17_6.Models;

public class Product
{
    public Product()
    {
    }

    public Product(string name, int productId, string email)
    {
        Name = name;
        ProductId = productId;
        Email = email;
    }

    public Product(int id, string name, int productId, string email)
    {
        ID = id;
        Name = name;
        ProductId = productId;
        Email = email;
    }
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Name { get; set; }
    public int ProductId { get; set; }
    public string Email { get; set; }
}
