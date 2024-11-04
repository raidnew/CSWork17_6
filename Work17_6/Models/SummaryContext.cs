using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Work17_6.Models;

public class SummaryContext : DbContext
{
    public SummaryContext() : base("DbConnect") { }
    
    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public BindingList<Product> GetItemSourceProducts()
    {
        Products.Load();
        return Products.Local.ToBindingList();
    }
    public BindingList<Customer> GetItemSourceCustomers()
    {
        Customers.Load();
        return Customers.Local.ToBindingList();
    }

    public void AddProductEntry(int productId, string productName, string email)
    {
        Product newPoroduct = new Product(productName, productId, email);
        Products.Add(newPoroduct);
        SaveChanges();
    }

    public void DeleteProductEntry(int id)
    {
        Products.Remove(Products.Single<Product>(p => p.ID == id));
        SaveChanges();
    }

    public void EditProductEntry(int id, int productId, string productName, string email)
    {
        Product data = Products.Single<Product>(p => p.ID == id);
        data.Name = productName;
        data.ProductId = productId;
        data.Email = email;
        SaveChanges();
    }

    public void EditCustomerEntry(int id, string firstName, string lastName, string thirdName, string email, string phone)
    {
        Customer customer = Customers.Single<Customer>(p => p.ID == id);
        customer.FirstName = firstName;
        customer.LastName = lastName;
        customer.ThirdName = thirdName;
        customer.Email = email;
        customer.Phone = phone;
        SaveChanges();
    }

    public void AddCustomerEntry(string firstName, string lastName, string thirdName, string email, string phone)
    {
        Customer newCustomer = new Customer(firstName, lastName, thirdName, email, phone);
        Customers.Add(newCustomer);
        SaveChanges();
    }

    public void DeleteCustomerEntry(int id)
    {
        Customers.Remove(Customers.Single<Customer>(c => c.ID == id));
        SaveChanges();
    }
}
