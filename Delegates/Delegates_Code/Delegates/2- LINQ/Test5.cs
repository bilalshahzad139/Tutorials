using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://msdn.microsoft.com/en-us/library/system.collections.ienumerator(v=vs.100).aspx
//IEnumerable & IEnumerator Example

namespace Delegates
{
    public class Person
    {
        public string firstName;
        public string lastName;
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }
    }

    //To make our collection "iteratable" and to use it with "forach"
    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;
        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                return _people[position];
            }
        }
    }//End of PeopleEnum

    public class People : IEnumerable
    {
        private Person[] _people;
        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }


    public class Test5
    {
        public void PerformTest()
        {
            Person[] peopleArray = new Person[3]
            {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon"),
            };

            //Example of Using IEnumerator
            PeopleEnum peopleEnumerator = new PeopleEnum(peopleArray);

            while (peopleEnumerator.MoveNext())
            {
                Person p = (Person)peopleEnumerator.Current;
                Console.WriteLine(p.firstName + " " + p.lastName);
            }


            
            //foreach (Person p in peopleEnumerator)
            //{
            //    Console.WriteLine(p.firstName + " " + p.lastName);
            //}






            //Example of Using IEnumerable
            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
            {
                Console.WriteLine(p.firstName + " " + p.lastName);
            }

            

        }

    }
}
