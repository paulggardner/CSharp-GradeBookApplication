using GradeBook.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks 
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var sortedStudents = Students.OrderByDescending(x => x.AverageGrade).ToArray();
            for (int i = 0; i < sortedStudents.Length - 1; i++)
            {
                if (averageGrade >= sortedStudents[i].AverageGrade)
                {
                    double ranking = ((i*1.0) / sortedStudents.Length) * 100;
                    if (ranking < 20) return 'A';
                    if (ranking < 40) return 'B';
                    if (ranking < 60) return 'C';
                    if (ranking < 80) return 'D';
                }
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
