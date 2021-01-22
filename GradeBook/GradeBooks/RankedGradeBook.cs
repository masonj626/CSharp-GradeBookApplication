﻿using System;
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
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("You must have at least 5 students to perform this operation");
            }

            var top20 = (int)Math.Ceiling(Students.Count * .2);
            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();

            if(averageGrade >= grades[top20-1])
            {
                return 'A';
            }
            else if(averageGrade >= grades[(top20 * 2)-1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[(top20 * 3) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[(top20 * 4) - 1])
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStatistics();
            return;
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStudentStatistics(name);
            return;
        }
    }
}
