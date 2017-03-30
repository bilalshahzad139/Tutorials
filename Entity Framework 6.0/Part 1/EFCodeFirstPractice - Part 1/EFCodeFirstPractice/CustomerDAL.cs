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
                var list = ctx.Customers.ToList();
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
    }
}
