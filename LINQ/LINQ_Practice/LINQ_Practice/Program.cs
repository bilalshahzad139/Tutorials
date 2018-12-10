using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<StudentDTO> list = new List<StudentDTO>();

            StudentDTO dto = new StudentDTO();
            dto.ID = 1;
            dto.Name = "Khurram";

            list.Add(dto);

            StudentDTO dto1 = new StudentDTO();
            dto1.ID = 2;
            dto1.Name = "Faisal";

            list.Add(dto1);

            StudentDTO dto2 = new StudentDTO();
            dto2.ID = 3;
            dto2.Name = "Waqas";

            list.Add(dto2);


            //Find those from list where ID = 3
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == 3)
                {
                    Console.WriteLine("Name is:{0}", list[i].Name);
                    break;
                }
            }
            System.Console.WriteLine("Press any key to conitnue");
            System.Console.ReadKey();

            //Find those from list where ID = 3 AND Name ="Faisal"
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == 3 && list[i].Name == "Faisal")
                {
                    Console.WriteLine("Name is:{0}", list[i].Name);
                    break;
                }
            }

            System.Console.WriteLine("Press any key to conitnue");
            System.Console.ReadKey();

            //Find those from list where ID = 3 OR Name ="Faisal"
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == 3 || list[i].Name == "Faisal")
                {
                    Console.WriteLine("Name is:{0}", list[i].Name);
                }
            }

            System.Console.WriteLine("Press any key to conitnue");
            System.Console.ReadKey();


            var obj = (from p in list where p.ID == 1 select p).FirstOrDefault();
            if(obj != null)
            {
                Console.WriteLine("Name is:{0}", obj.Name);
            }

            System.Console.WriteLine("Press any key to conitnue");
            System.Console.ReadKey();


            var obj1 = (from p in list where (p.ID == 3 && p.Name == "Faisal")  select p).FirstOrDefault();
            if (obj1 != null)
            {
                Console.WriteLine("Name is:{0}", obj1.Name);
            }

            System.Console.WriteLine("Press any key to conitnue");
            System.Console.ReadKey();

            var result = (from p in list where (p.ID == 3 || p.Name == "Faisal") select p).ToList();
            foreach (var item in result)
            {
                Console.WriteLine("ID:{0}, Name is:{1}", item.ID, item.Name);
            }

            // Use of Orderby and multiline query
            var result1 = (from p in list 
                           orderby p.ID descending 
                           select p).ToList();

            //Select specific column
            var result2 = (from p in list
                           select p.ID).ToList();

            
            //Select specific columns
            var result3 = (from p in list
                           select new { p.ID, p.Name }).ToList();


            //Find those from list where ID = 3
            var r1 = list.Where(p => p.ID == 3).FirstOrDefault();

            //Find those from list where ID = 3 AND Name ="Faisal"
            var r2 = list.Where(p => p.ID == 3 && p.Name == "Faisal").FirstOrDefault();

            //Find those from list where ID = 3 OR Name ="Faisal"
            var r3 = list.Where(p => p.ID == 3 || p.Name == "Faisal").ToList();

            //Order By
            var r4 = list.OrderByDescending(p => p.ID).ToList();

            //Select specific column
            var r5 = list.Select(p => p.ID).ToList();

            //Select specific columns
            var r6 = list.Select(p => new { p.ID, p.Name }).ToList();

            //Where & Select specific columns
            var r7 = list.Where(p=> p.ID ==3).Select(p => new { p.ID, p.Name }).ToList();


            System.Console.ReadKey();
        }
    }

    class StudentDTO
    {
        public int ID { get; set; }
        public String Name { get; set; }
    }

}


