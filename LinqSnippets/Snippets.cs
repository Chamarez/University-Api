using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinq()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A4",
                "Audi A5",
                "Fiat Punto",
                "Fiat Ibiza",
                "Seat Leon"
            };

            // 1. Select * of cars (ALL CARS)

            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. Select where   (SELECT AUDIS)

            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }

            //Numbers examples


        }

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //each number * 3 
            //take all numbers, but 9
            // order by ascending 
            var processedNumberList = numbers.Select(num => num * 3).Where(num => num != 9).OrderBy(num => num);
        }
        static public void SearchExamples()
        {
            List<string> textList = new List<string>
         {
             "a",
             "bx",
             "c",
             "d",
             "e",
             "cj",
             "f",
             "c"
         };

            var first = textList.First();
            var cText = textList.First(text => text.Equals("c"));
            var jText = textList.First(text => text.Contains("j"));
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));
            var uniqueText = textList.Single();
            var uniqueTextOrDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);

        }

        static public void MultipleSelect()
        {
            //Select Many
            string[] myOpinion =
            {
                "Opinion 1, text 1",
                 "Opinion 2, text 2",
                  "Opinion 3, text 3",
            };
            var myOpinionSelection = myOpinion.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id=1,
                    Name="Enterprise 1",
                    Employees= new[]
                    {
                        new Employee(){
                            Id=1,
                            Name="Martin",
                            Email="m@m.com",
                            Salary=3000
                        },
                        new Employee(){
                            Id=2,
                            Name="Pepe",
                            Email="m@m.com",
                            Salary=3000
                        },
                        new Employee(){
                            Id=3,
                            Name="Juanjo",
                            Email="m@m.com",
                            Salary=3555
                        },

                    }
                },
                new Enterprise()
                {
                    Id=2,
                    Name="Enterprise 1",
                    Employees= new[]
                    {
                        new Employee(){
                            Id=4,
                            Name="Martin",
                            Email="m@m.com",
                            Salary=3000
                        },
                        new Employee(){
                            Id=5,
                            Name="Martin",
                            Email="m@m.com",
                            Salary=5000
                        },
                        new Employee(){
                            Id=6,
                            Name="Martin",
                            Email="m@m.com",
                            Salary=9000
                        },

                    }
                }
            };

            //obtain all employees of all enterprices 
            var employerList = enterprises.SelectMany(enterprise => enterprise.Employees);
            //know if an list is empty
            bool hasEnterprises = enterprises.Any();
            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());
            bool hasEmployeeWithSalaryMoreThan1000 = enterprises.Any(enterprise => enterprise.Employees.Any(employee=>employee.Salary>1000));



        }




        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };

            var secondList = new List<string>() { "a", "c", "d" };


            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };   


            var commondResult2 = firstList.Join(
                secondList, 
                element=>element,
                secondElement => secondElement,
                (element, secondElement)=> new { element, secondElement });


            //outer join left
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element=element};

            var leftOuterJoin2 = from element in firstList 
                                 from secondElement in secondList.Where(s => s==element).DefaultIfEmpty() 
                                 select new { Element = element, SecondElement = secondElement };

            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };


            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);

           


        }

        static public void SkipTakeLinq()
        {
            var myList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var skypTwoFirstValues = myList.Skip(2);

            var skypLastTwoValues = myList.SkipLast(2);

            var skypWhileSmallerThanFour = myList.SkipWhile(element => element < 4 );
            
            var takeFirstTwoValues = myList.Take(2);
           
            var takeLastTwoValues = myList.TakeLast(2);

            var takeWhileSmallerThanFour = myList.TakeWhile(element=>element<4);


        }




    }


}