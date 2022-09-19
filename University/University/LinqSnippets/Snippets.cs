using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            var carList = from car in cars select car;
            foreach(var car in carList)
                Console.WriteLine(car);

            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var car in audiList)
                Console.WriteLine(car);

        }

        static public void LinQNumbers()
        {
            int[] numbers = { 1,2,3,4,5,6,7,8,9 };

            // Each number multiplied by 3
            // take all numbers, but 9
            // order numbers by ascending value

            var processedNumberList = 
                numbers.Select(num => num*3)
                .Where(num => num !=9)
                .OrderBy(num => num);

            
        }

        static public void SearchExaples()
        {
            List<string> textList = new List<string> { "a","bx","c","d","e","cj","f", "c" };

            // el primero
            var firt = textList.First();

            // la primer "c"
            var cText = textList.First(text => textList.Equals("c"));

            // la primer "que contiene una j"
            var jText = textList.First(text => textList.Contains("j"));

            // la primer "que contiene una z" o valor por defecto
            var firstOrDefault = textList.FirstOrDefault(text => textList.Contains("z"));

            // la primer "que contiene una z" o valor por defecto
            var lastOrDefault = textList.LastOrDefault(text => textList.Contains("z"));


            // la primer "que contiene una z" o valor por defecto
            var singleText = textList.Single();
            var singleOrDefault = textList.SingleOrDefault();


            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            // obtener los que no se repiten
            var noSeRepiten = evenNumbers.Except(otherEvenNumbers);

        }

        static public void MultipleSelect()
        {
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(myOpinions => myOpinions.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1, Name = "Martin", Email = "martin@gmail.com", Salary = 3000
                        },
                        new Employee()
                        {
                            Id = 2, Name = "Pepe", Email = "pepe@gmail.com", Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 3, Name = "Juanjo", Email = "juanjo@gmail.com", Salary = 2000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 4, Name = "Ana", Email = "Ana@gmail.com", Salary = 3000
                        },
                        new Employee()
                        {
                            Id = 5, Name = "Maria", Email = "Maria@gmail.com", Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 6, Name = "Marta", Email = "Marta@gmail.com", Salary = 2000
                        }
                    }
                }
            };

            // obtener todos los empleados de todas las empresas
            var employeeList = enterprises.SelectMany(enterprises => enterprises.Employees);

            bool hasEnterprises = enterprises.Any();
            bool hasEmployees = enterprises.Any(enterprises => enterprises.Employees.Any());


            // mas de 1000 euros
            bool hasEmployeesWithSalaryMoreThat1000 = 
                enterprises.Any(enterprises => 
                    enterprises.Employees.Any(employee => employee.Salary > 1000));

        }

        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };


            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                ( element, secondElement ) => new { element, secondElement }
            );


            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into termporalList
                                from termporalElement in termporalList.DefaultIfEmpty()
                                where element != termporalElement
                                select new { Element = element };


            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };

            // OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                join element in firstList
                                on secondElement equals element 
                                into termporalList
                                from termporalElement in termporalList.DefaultIfEmpty()
                                where secondElement != termporalElement
                                select new { Element = secondElement };

            var rightOuterJoin2 = from secondElement in secondList
                                  from element in firstList.Where(s => s == secondElement).DefaultIfEmpty()
                                  select new { Element = element, SecondElement = secondElement };


            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                 1,2,3,4,5,6,7,8,9
            };

            // SKIP

            var skipTwoFirstValues = myList.Skip(2);
            var skipTwoLastValues = myList.SkipLast(2);

            var skipWhile = myList.SkipWhile(num => num < 4);

            // TAKE
            var takeTwoFirstValues = myList.Take(2);
            var takeTwoLastValues = myList.TakeLast(2);

            var takeWhile = myList.TakeWhile(num => num < 4);

        }

        // TODO
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int starIndex = (pageNumber-1) * resultsPerPage;
            
            // con Skip me salto los primeros elementos... con take me quedo con los siguientes
            return collection.Skip(starIndex).Take(resultsPerPage);
        }


        // Variables
        static public void LinqVariables()
        {
            int[] numbers = {1,2,3,4,5,6,7,8,9,10};

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let sSqared = Math.Pow(number, 2)
                               where sSqared > average
                               select number;

            foreach( int number in aboveAverage)
            {
                Console.WriteLine("Number: {0} - Square: {1}", number, Math.Pow(number, 2));
            }
        }


        // ZIP
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "uno", "dos", "tres", "cuatro", "cinco"};

            IEnumerable<string> zipNumber = numbers.Zip(stringNumbers, (num, word) => num + "-" + word);
        }

        // Repeate and range
        static public void repeatRangeLinq()
        {

            // generar un rango de valores del 1 al 1000
            var first1000 = Enumerable.Range(1, 1000);

            var aboveAverage = from number in first1000
                               select number;

            // repetir un valor varias veces
            var fiveX = Enumerable.Repeat("X", 5);

        }

        static public void StudentsLinq()
        {

            var classRoom = new[]
            {
                new Student() { Id = 1, Name="Martin", Certificated = true, Grade = 90 },
                new Student() { Id = 2, Name="Juan", Certificated = false, Grade = 50 },
                new Student() { Id = 3, Name="Ana", Certificated = true, Grade = 96 },
                new Student() { Id = 4, Name="Alvaro", Certificated = false, Grade = 10 },
                new Student() { Id = 5, Name="Pedro", Certificated = true, Grade = 50 }
            };

            var certifiesStudiente = from student in classRoom
                                     where student.Certificated
                                     select student;

            var noCertifiesStudent = from student in classRoom
                                     where !student.Certificated
                                     select student;

            var aprovedStudent = from student in classRoom
                                 where student.Certificated && student.Grade >= 50
                                 select student.Name;


        }

        // ALL
        static public void AllLinq()
        {

            int[] numbers = { 1, 2, 3, 4, 5 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10);

            bool allAreBiggerOrEqualThan2 = numbers.All(x => x < 2);


            var emptyList = new List<int>();
            bool allAreBiggerOrEqualThan0 = emptyList.All(x => x > 0);

        }

        // Aggregate
        static public void AggregateQuerys()
        {

            int[] numbers = { 1, 2, 3, 4, 5,6,7,8,9,10 };

            // sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);


            string[] words = { "hello", "my", "mane","is","Martin" };

            // sum all numbers
            string greating = words.Aggregate((prevGreating, current) => prevGreating + current);

        }

        // Disctinct
        static public void DisctinctValues()
        {

            int[] numbers = { 1, 2, 3, 4, 5, 5,4,3,2,1 };

            IEnumerable<int> values = numbers.Distinct();
        }

        // GroupBy
        static public void GroupByExample()
        {

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6,7,8, 9};

            // obtain only even number an generate two group
            var grouped = numbers.GroupBy(x => x%2 == 0);


            // we will habe two groups
            // 1. The group that doesnt fit the condition
            // 2. The group that fit the condition

            foreach(var group in grouped)
            {
                foreach(var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9  ... 2,4,6,8 (firs the odds and then even)
                }
            }

            var classRoom = new[]
            {
                new Student() { Id = 1, Name="Martin", Certificated = true, Grade = 90 },
                new Student() { Id = 2, Name="Juan", Certificated = false, Grade = 50 },
                new Student() { Id = 3, Name="Ana", Certificated = true, Grade = 96 },
                new Student() { Id = 4, Name="Alvaro", Certificated = false, Grade = 10 },
                new Student() { Id = 5, Name="Pedro", Certificated = true, Grade = 50 }
            };


            var certifiedQuery = classRoom.GroupBy(student => student.Certificated);
    
            foreach(var group in certifiedQuery)
            {

                Console.WriteLine("------- {0} ------------", group.Key);

                foreach(var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }

        }

        static public void RelationsLinq()
        { 
            List<Post> posts = new List<Post>() 
            { 
                new Post() {  Id = 1, Title = "My first post", Content = "My first content", Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment() { Id = 1, Created=DateTime.Now, Content = "My first content", Title = "Mi first comment" },
                        new Comment() { Id = 2, Created=DateTime.Now, Content = "My second content", Title = "Mi second comment" }
                    }
                },
                new Post() {  Id = 2, Title = "My second post", Content = "My second content", Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment() { Id = 3, Created=DateTime.Now, Content = "My first content", Title = "Mi first comment" },
                        new Comment() { Id = 4, Created=DateTime.Now, Content = "My second content", Title = "Mi second comment" }
                    }
                },
            };

            var commentsContent = 
                posts.SelectMany(
                    post => post.Comments, 
                    (post, comment) => new { PostId = post.Id, CommentContent = comment.Content }
                    );
        
        }

    }
}