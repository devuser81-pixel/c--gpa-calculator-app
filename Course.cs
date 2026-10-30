namespace GpaCalculatorApp
{
    public class Course
    {
        public string Code { get; set; } = string.Empty;
        public int Units { get; set; }
        public double Score { get; set; }

        public (string Grade, int Point) GetGradeAndPoint()
        {
            return Score switch
            {
                >= 70.0 => ("A", 5),
                >= 60.0 => ("B", 4),
                >= 50.0 => ("C", 3),
                >= 45.0 => ("D", 2),
                >= 40.0 => ("E", 1),
                _ => ("F", 0)
            };
        }
    }
}
