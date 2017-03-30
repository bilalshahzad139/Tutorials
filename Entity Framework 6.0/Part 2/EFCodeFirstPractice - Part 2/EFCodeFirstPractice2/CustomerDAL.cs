using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCodeFirstPractice
{
    public class CustomerDAL
    {
        public void SaveCustomer(CustomerDTO dto)
        {
            using (var ctx = new MyDBContext())
            {
                ctx.Customers.Add(dto);
                ctx.SaveChanges();
            }
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            using (var ctx = new MyDBContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //Include function takes path of navigation property
                //In our example, navigation property name is "Accounts"
                var list = ctx.Customers.Include("Accounts").ToList();
                return list;
            }
        }
        public List<CustomerDTO> GetAllCustomersExplicitly()
        {
            using (var ctx = new MyDBContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                var list = ctx.Customers.ToList();
                foreach (var cust in list)
                {
                    ctx.Entry(cust).Collection(p => p.Accounts).Load(); 
                }
                return list;
            }
        }

        public CustomerDTO GetCustomerByID(int id)
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
                return obj;
            }
        }
        public void DeleteCustomer(int id)
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
                ctx.Customers.Remove(obj);
                ctx.SaveChanges();
            }
        }

        public void UpdateCustomer(CustomerDTO dto)
        {
            using (var ctx = new MyDBContext())
            {
                //Read the object from database
                var obj = ctx.Customers.Where(c => c.CustomerID == dto.CustomerID).FirstOrDefault();
                //Make changes
                obj.Name = dto.Name;
                obj.Address = dto.Address;
                //Save Changes
                ctx.SaveChanges();
            }
        }

        public void UpdateCustomer2(CustomerDTO dto)
        {
            using (var ctx = new MyDBContext())
            {
                //Attach our object to context
                ctx.Customers.Attach(dto);

                //Get Entry to tell which columns are modified
                var entry = ctx.Entry(dto);
                //Set state of entity/all columns to "Unchanged"
                entry.State = System.Data.Entity.EntityState.Unchanged;
                //Now change state of columns which were modified
                entry.Property(e => e.Name).IsModified = true;
                
                //It will generate 'Update' Statement
                ctx.SaveChanges();
            }
        }
        public void DeleteCustomer2(int id)
        {
            //Create a dummy dto to attach
            var dto = new CustomerDTO() { 
                CustomerID = id
            };
            using (var ctx = new MyDBContext())
            {
                //Get Entry to tell its state (it will automatically attach)
                var entry = ctx.Entry(dto);
                //Set state of entity to "Deleted"
                entry.State = System.Data.Entity.EntityState.Deleted;
                
                //It will generate 'Delete' Statement for above entity
                ctx.SaveChanges();
            }
        }


       
    }
}
