using System;
using System.Collections.Generic;
using System.Linq;

namespace GpaCalculatorApp
{
    public class Calculator
    {
        public static double ComputeGpa(List<Course> courses)
        {
            if (courses == null || courses.Count == 0) return 0.0;

            int totalUnits = courses.Sum(c => c.Units);
            int totalQualityPoints = courses.Sum(c => c.Units * c.GetGradeAndPoint().Point);

            if (totalUnits == 0) return 0.0;

            return Math.Round((double)totalQualityPoints / totalUnits, 2);
        }

        public static bool RunSelfChecks()
        {
            var testCourses = new List<Course>
            {
                new Course { Code = "TEST101", Units = 3, Score = 75.0 }, // A -> 5 * 3 = 15 pts
                new Course { Code = "TEST102", Units = 3, Score = 42.0 }  // E -> 1 * 3 = 3 pts
            };

            double computedGpa = ComputeGpa(testCourses);
            int totalUnits = testCourses.Sum(c => c.Units);
            int totalPoints = testCourses.Sum(c => c.Units * c.GetGradeAndPoint().Point);

            // Assertions: 6 total units, 18 total quality points, GPA = 3.00
            bool unitsCheck = totalUnits == 6;
            bool pointsCheck = totalPoints == 18;
            bool gpaCheck = Math.Abs(computedGpa - 3.00) < 0.001;

            return unitsCheck && pointsCheck && gpaCheck;
        }
    }
}