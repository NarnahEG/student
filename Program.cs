// Program.cs - Main entry point
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating an array of 10 students with names and ages
        string[] studentNames = new string[] { "Mobola", "Janet", "Gideon", "Lara", "Divine", "Solomon", "Dominic", "Jasmine", "Seun", "Dennis" };
        int[] studentAges = new int[] { 25, 16, 18, 19, 24, 22, 30, 15, 26, 18 };

        // Get students grouped by their ages
        Dictionary<int, List<string>> studentsByAge = StudentData.GetStudentsWithAge(studentAges, studentNames);

        int ageToCheck = 18;
        if (studentsByAge.TryGetValue(ageToCheck, out List<string>? studentsWithAge))
        {
            Console.WriteLine($"The following students are {ageToCheck} years old:");
            foreach (string student in studentsWithAge)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine($"No student with age {ageToCheck} found in the list.");
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class StudentData
    {
        public static Dictionary<int, List<string>> GetStudentsWithAge(int[] studentAges, string[] studentNames)
        {
            if (studentAges == null || studentNames == null || studentAges.Length != studentNames.Length)
            {
                Console.WriteLine("Error: Invalid input arrays.");
                return new Dictionary<int, List<string>>();
            }

            Dictionary<int, List<string>> studentsByAge = new Dictionary<int, List<string>>();

            for (int i = 0; i < studentAges.Length; i++)
            {
                int age = studentAges[i];
                string name = studentNames[i];

                if (!studentsByAge.ContainsKey(age))
                {
                    studentsByAge[age] = new List<string>();
                }

                studentsByAge[age].Add(name);
            }

            return studentsByAge;
        }

    }
}
