using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work17_6.Models;

public class Customer
{
    public Customer()
    {
    }
    public Customer(string firstName, string lastName, string thirdName, string phone, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        ThirdName = thirdName;
        Phone = phone;
        Email = email;
    }

    public Customer(int id, string firstName, string lastName, string thirdName, string phone, string email)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        ThirdName = thirdName;
        Phone = phone;
        Email = email;
    }
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string FirstName{ get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
