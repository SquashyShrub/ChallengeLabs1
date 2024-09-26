using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeLabs1
{
    internal abstract class SchoolSubjects
    {
        //Subjects taught at the school
        public int PhysicsGrade { get; set; }

        public int ChemistryGrade { get; set; }

        public int ComputerAppGrade { get; set; }


        //GRADING - Cannot set in Program.cs
        private int totalgrade;
        public int TotalGrade
        {
            get
            {
                return totalgrade;
            }
        }

        private int percentageavg;
        public int PercentAvg
        {
            get
            {
                return percentageavg;
            }
        }

        private string gradedivision;
        public string GradeDivision
        {
            get
            {
                return gradedivision;
            }
        }
        
        
        //METHODS
        public int TotalMarksCalculation()
        {
            return PhysicsGrade + ChemistryGrade + ComputerAppGrade;
        }

        public int PercentAvgCalculation()
        {
            return (PhysicsGrade + ChemistryGrade + ComputerAppGrade) / 3;
        }

        public string GradeDivisionCalculation()
        {
            if (PercentAvgCalculation() >= 90)
            {
                return "First Division";
            }
            else if (PercentAvgCalculation() >= 75 && PercentAvgCalculation() < 90)
            {
                return "Second Division";
            }
            else if (PercentAvgCalculation() < 75)
            {
                return "Third Division";
            }
            return "No Division";
        }
    
    
    
    }
}
