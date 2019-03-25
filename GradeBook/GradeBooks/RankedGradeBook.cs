using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            
            if (BaseGradeBook.Students.Count < 5)
                {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2); //cast to integer for things that accept only integer types
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';




                    //if (grade > Math.Round(BaseGradeBook.Students.Length / 5 * 4))
                    //    {
                    //    return 'A';
                    //}
                    //else if (grade > Math.Round(BaseGradeBook.Students.Length / 5 * 3))
                    //    {
                    //    return 'B';
                    //}
                    //else if (grade > Math.Round(BaseGradeBook.Students.Length / 5 * 2))
                    //    {
                    //    return 'C';
                    //}
                    //else if (grade > Math.Round(BaseGradeBook.Students.Length / 5))
                    //    {
                    //    return 'D';
                    //}
                    //else
                    //{
                    //    return 'F';
                    //}

            
        }
    }
}
