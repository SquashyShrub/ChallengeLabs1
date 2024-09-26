using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeLabs1
{
    internal class Program : Student
    {
        
        static void Main(string[] args)
        {
            char char_choice_yn = 'y';
            int num_choice = 0;
            string active = "active";

            while (active == "active")
            {
                Console.WriteLine("Welcome to the first set of Challenge Labs!\nPlease log in to continue.");
                ////CHALLENGE LAB 2////
                UserIdAndPasswordInput();
                
                
                while (char_choice_yn == 'y')
                {
                    switch (num_choice)
                    {
                        case 0:
                            //Menu//
                            Console.WriteLine("Please choose which lab to see.\n" +
                                "[1] Challenge Lab 1: Weather Description\n" +
                                "[2] Challenge Lab 3: Inverted Triangle\n" +
                                "[3] Challenge Lab 4: Add a Students Grade\n" +
                                "[4] Exit Menu\n" +
                                "[5] Exit Program\n");

                            //Menu Selection
                            num_choice = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 1:
                            challengeLabTitle(1);
                            ////CHALLENGE LAB 1////
                            WeatherDesc();
                            goBackToMenu();
                            break;
                        
                        case 2:
                            challengeLabTitle(3);
                            ////CHALLENGE LAB 3////
                            InvertedTriangle();
                            goBackToMenu();
                            break;

                        case 3:
                            challengeLabTitle(4);
                            ////CHALLENGE LAB 4////
                            AddStudentsGrade();
                            goBackToMenu();
                            break;

                        case 4:
                            active = "deactive";
                            goBackToMenu();
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Input was invalid. Please select a number from the list.");
                            break;
                    }
                    void challengeLabTitle(int num)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Challenge lab {num}");
                        Console.WriteLine(("").PadRight(24, '-'));
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    void goBackToMenu()
                    {
                        if (char_choice_yn == 'y' && active == "active")
                        {
                            Console.WriteLine("Would you like to go back to the menu? [Y/N]");
                            //Make sure input is only one character long
                            CharInput:
                            try
                            {
                                char_choice_yn = char.Parse(Console.ReadLine().ToLower());
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor= ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                goto CharInput;
                            }

                            if (char_choice_yn == 'y')
                            {
                                char_choice_yn = 'y';
                                num_choice = 0;
                            }
                            else
                            {
                                char_choice_yn = 'n';
                                active = "deactive";
                            }
                        }
                        else
                        {
                            char_choice_yn = 'n';
                            active = "deactive";
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("That concludes the lab demonstrations. You may press any key to exit.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }
        static void UserIdAndPasswordInput()
        {
            string userid = "Admin";
            string password = "Password";
            int wrongCounter = 0;
            int attemptsRemaining = 3;

            Console.WriteLine("\nEnter user ID and password.");
            userid = Console.ReadLine();
            password = Console.ReadLine();
            while (attemptsRemaining > 1)
            {
                if (userid.Contains("Admin") && password.Contains("Password")) // All credit to Richard Disney for showing the '.Contains' method. Makes life so much easier
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{userid}, Welcome!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    attemptsRemaining = 0;
                    //goto ExitLoop;
                }
                else
                {
                    wrongCounter++;
                    attemptsRemaining--;
                    Console.WriteLine("Invalid User ID or Password. Please try again.");
                    Console.WriteLine($"{attemptsRemaining} attempts remaining");
                    Console.WriteLine("Enter User ID:");
                    userid = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    password = Console.ReadLine();
                }
            }
            //Locked Out
            if (wrongCounter >= 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYou have no attempts remaining. Please exit the program.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Environment.Exit(0);

            }
            Console.WriteLine();
            
        }

        static void WeatherDesc()
        {
            int temp = 0;
            Console.WriteLine("What is the temperature right now?");
            temp = int.Parse(Console.ReadLine());

            if (temp <= 10) { Console.WriteLine("Freezing Weather\n"); }
            else if (temp >= 11 && temp <= 20) { Console.WriteLine("Very Cold Weather\n"); }
            else if (temp >= 21 && temp <= 35) { Console.WriteLine("Cold Weather\n"); }
            else if (temp >= 36 && temp <= 50) { Console.WriteLine("Normal Weather\n"); }
            else if (temp >= 51 && temp <= 65) { Console.WriteLine("Hot Weather\n"); }
            else if (temp >= 66 && temp <= 80) { Console.WriteLine("Very Hot Weather\n"); }
            else if (temp > 80) { Console.WriteLine("Normal day in the West Coast USA\n"); }
        }

        static void InvertedTriangle()
        {
            //Instructions and user input
            int num;
            int rows = 1;
            string exitLoop = "false";

            Console.WriteLine("Write the number you want to display. Please use single digits only.");
            bool numFlag = int.TryParse(Console.ReadLine(), out num);
            while (exitLoop == "false")
            {
                if (numFlag == true && num <= 9)
                {
                    Console.WriteLine("Now write how many rows you want for the triangle. Do not exceed 20.");
                    bool rowsFlag = int.TryParse(Console.ReadLine(), out rows);
                    if (rowsFlag == true && rows <= 20)
                    {
                        //Triangle logic
                        for (int i = rows; i >= 1; i--) //'i' is equal to the amount of rows. As long as 'i' is greater than or equal to 1 (because we are going backwards), run the 2nd for loop
                        {
                            for (int j = 1; j <= i; j++) //'j' is equat to 1, as long as 'j' is less than or equal to 'i', the we write the num in a write() method.
                            {
                                Console.Write(num);
                            }
                            Console.WriteLine();
                        }
                        exitLoop = "true";
                    }
                    else
                    {
                        Console.WriteLine("Please pick a number no larger than 20");
                    }
                }
                else
                {
                    Console.WriteLine("Please pick a number no larger than 9");
                    num = int.Parse(Console.ReadLine());
                }
            }
        }
        static void AddStudentsGrade()
        {                                   /////////NEED TRY AND CATCH ERRORS - - LAST DEBUG////////
            Student student = new Student();

            //Input student info
            RollNumberInput:
            try
            {
                Console.WriteLine("Enter the students roll number");
                student.rollNumber = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input invalid. Please enter a number.");
                Console.ForegroundColor = ConsoleColor.White;
                goto RollNumberInput;
            }
            GradeInputs:
            try
            {
                Console.WriteLine("\nEnter the full name of the student");
                student.studentName = Console.ReadLine();

                Console.WriteLine("\nEnter Physics grade in number formal: ");
                student.PhysicsGrade = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("\nEnter Chemistry grade in nuumber format: ");
                student.ChemistryGrade = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("\nEnter Computer Application grade in number format: ");
                student.ComputerAppGrade = int.Parse(Console.ReadLine());

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("User input invalid. Please reenter student data.");
                Console.ForegroundColor = ConsoleColor.White;
                goto GradeInputs;
            }
            

            //Writing all of this to console
            Console.WriteLine($"\nRoll Number:\t\t\t{student.rollNumber}\n" +
                $"Student Name:\t\t\t{student.studentName}\n" +
                $"Physics Grade:\t\t\t{student.PhysicsGrade}\n" +
                $"Chemistry Grade:\t\t{student.ChemistryGrade}\n" +
                $"Computer Application Grade:\t{student.ComputerAppGrade}\n\n");
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine("Total Marks:\t" + student.TotalMarksCalculation());
            Console.WriteLine("Percentage:\t" + student.PercentAvgCalculation() + "%");
            Console.WriteLine("Division:\t" + student.GradeDivisionCalculation());
        }
    }
}
