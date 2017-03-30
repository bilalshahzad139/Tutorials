using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.Validation;

namespace EFCodeFirstPractice
{
    public class CustomerDAL
    {
        public void SaveCustomer(CustomerDTO dto)
        {
            try
            {
                using (var ctx = new MyDBContext()){
                    ctx.Customers.Add(dto);
                    ctx.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendLine(String.Format("- {0} : {1}", error.PropertyName, error.ErrorMessage));
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" 
                    + sb.ToString(), ex); 
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
            var dto = new CustomerDTO()
            {
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

        public List<CustomerDTO> GetAllCustomers_Method()
        {
            using (var ctx = new MyDBContext())
            {
                var query = ctx.Customers;
                return query.ToList();
            }
        }
        public List<CustomerDTO> GetAllCustomers_Query()
        {
            using (var ctx = new MyDBContext())
            {
                //This is query in memory
                var query = from c in ctx.Customers
                            select c;

                //It will be executed now
                var result = query.ToList();

                return result;
            }
        }

        public List<CustomerDTO> GetCustomersByName_Method(String name)
        {
            using (var ctx = new MyDBContext())
            {
                var query = ctx.Customers.Where(c => c.Name.StartsWith(name));
                return query.ToList();
            }
        }
        public List<CustomerDTO> GetCustomersByName_Query(String name)
        {
            using (var ctx = new MyDBContext())
            {
                //This is query in memory
                var query = from c in ctx.Customers
                            where c.Name.StartsWith(name) == true
                            select c;
                //It will be executed now
                var result = query.ToList();
                return result;
            }
        }

        public List<Object> GetCustomersByNameLen_Method()
        {
            using (var ctx = new MyDBContext())
            {
                var query = ctx.Customers
                    .Where(c => c.Name.Length > 3).Select(c => new { c.CustomerID, c.Name });
                List<Object> list = new List<Object>();
                foreach (var o in query)
                {
                    list.Add(o);
                }
                return list;
            }
        }
        public List<Object> GetCustomersByNameLen_Query()
        {
            using (var ctx = new MyDBContext())
            {
                var query = from c in ctx.Customers
                            where c.Name.Length > 3
                            select new { c.CustomerID, c.Name };
                List<Object> list = new List<Object>();
                foreach (var o in query)
                {
                    list.Add(o);
                }
                return list;
            }
        }

        public List<CustAccountSimpleDTO> GetCustAccount_Query()
        {
            using (var ctx = new MyDBContext())
            {
                var query = from p in ctx.Customers
                            from a in ctx.Accounts
                            where p.CustomerID == a.CustomerID
                            select new CustAccountSimpleDTO
                            {
                                CustomerName = p.Name,
                                AccountNumber = a.AccountNumber
                            };
                var result = query.ToList();
                return result;
            }
        }

        public List<CustAccountSimpleDTO> GetCustAccount_Join_Query()
        {
            using (var ctx = new MyDBContext())
            {
                var query = from p in ctx.Customers
                            join a in ctx.Accounts on p.CustomerID equals a.CustomerID
                            select new CustAccountSimpleDTO
                            {
                                CustomerName = p.Name,
                                AccountNumber = a.AccountNumber
                            };
                var result = query.ToList();
                return result;
            }
        }

        public List<CustAccountSimpleDTO> GetCustAccount_SP()
        {
            using (var ctx = new MyDBContext())
            {
                //This is our RAW query (which can be any query)
                var sqlQuery = "execute dbo.GetCustomerAccounts";
                var result = ctx.Database.SqlQuery<CustAccountSimpleDTO>(sqlQuery).ToList();
                return result;
            }
        }
    }
}
