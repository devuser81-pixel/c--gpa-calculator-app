using System;
using System.Collections.Generic;
using System.Linq;

namespace GpaCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("   C# GPA CALCULATOR - VERIFICATION RUNTIME     ");
            Console.WriteLine("=================================================");

            // 1. Programmatic Self-Check Verification
            bool selfCheckPassed = Calculator.RunSelfChecks();
            Console.WriteLine($"[VERIFICATION CHECK] Programmatic Self-Test Passed: {selfCheckPassed}");
            Console.WriteLine("-------------------------------------------------\n");

            if (!selfCheckPassed)
            {
                Console.WriteLine("ERROR: Internal self-checks failed! Halting execution.");
                return;
            }

            // 2. Define Sample Semester Courses (4-Course Load)
            var semesterCourses = new List<Course>
            {
                new Course { Code = "CSC301", Units = 3, Score = 75.5 }, // Grade A (5 pts) -> 15 QP
                new Course { Code = "MTH301", Units = 4, Score = 62.0 }, // Grade B (4 pts) -> 16 QP
                new Course { Code = "GST111", Units = 2, Score = 81.0 }, // Grade A (5 pts) -> 10 QP
                new Course { Code = "PHY101", Units = 3, Score = 48.0 }  // Grade D (2 pts) -> 6 QP
            };

            // 3. Render Formatted Auditable ASCII Table
            Console.WriteLine("+-------------+-------+-------+-------+--------+----------------+");
            Console.WriteLine("| Course Code | Units | Score | Grade | Points | Quality Points |");
            Console.WriteLine("+-------------+-------+-------+-------+--------+----------------+");

            foreach (var course in semesterCourses)
            {
                var (grade, point) = course.GetGradeAndPoint();
                int qualityPoints = course.Units * point;
                Console.WriteLine($"| {course.Code,-11} | {course.Units,5} | {course.Score,5:F1} | {grade,5} | {point,6} | {qualityPoints,14} |");
            }

            Console.WriteLine("+-------------+-------+-------+-------+--------+----------------+");

            // 4. Calculate Cumulative Aggregates
            int totalUnits = semesterCourses.Sum(c => c.Units);
            int totalQualityPoints = semesterCourses.Sum(c => c.Units * c.GetGradeAndPoint().Point);
            double finalGpa = Calculator.ComputeGpa(semesterCourses);

            Console.WriteLine($"| TOTALS      | {totalUnits,5} |       |       |        | {totalQualityPoints,14} |");
            Console.WriteLine("+-------------+-------+-------+-------+--------+----------------+");
            Console.WriteLine($"\nFINAL CALCULATED GPA: {finalGpa:F2} / 5.00");
            Console.WriteLine("=================================================");
        }
    }
}