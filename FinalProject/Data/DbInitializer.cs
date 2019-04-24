
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public static class DbInitializer
    {
        //private static object studentterms;

        public static void Initialize(ApplicationDbContext context)
        {
          
            if (context.Degrees.Any())
            {
                Console.WriteLine("Degreess already exist");
            }
            else
            {
                
                var degrees = new Degree[] {
                     new Degree{DegreeID =1,DegreeAbbrev = "ACS+2",DegreeName = "MsACS+2",NumberOFTerms = 5},
                     new Degree{DegreeID =2,DegreeAbbrev = "ACS+DB",DegreeName = "MsACS+DB",NumberOFTerms = 5},
                      new Degree{DegreeID =3,DegreeAbbrev = "ACS+NF",DegreeName = "MsACS+NF",NumberOFTerms = 5},
                       new Degree{DegreeID =4,DegreeAbbrev = "ACS",DegreeName = "MsACS",NumberOFTerms = 5}
                };
                Console.WriteLine($"Inserted{degrees.Length} new students.");
                foreach (Degree s in degrees)
                {
                    context.Degrees.Add(s);
                }
                context.SaveChanges();
            }

            if (context.Credits.Any())
            {
                Console.WriteLine("Credits already exist");
            }
            else
            {
                var credits = new Credit[] {
                    new Credit{CreditID = 356,CreditAbbrev = "NF",CreditName = "Network Fundamentals",IsSummer = 0,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 542,CreditAbbrev = "542",CreditName = "OOPS with JAVA",IsSummer = 0,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 563,CreditAbbrev = "563",CreditName = "Web Apps",IsSummer = 0,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 560,CreditAbbrev = "560-ADB",CreditName = "Advanced Databases",IsSummer = 1,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 664,CreditAbbrev = "664-UX",CreditName = "User Experience Design",IsSummer = 0,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 618,CreditAbbrev = "618-PM",CreditName = "Project Management",IsSummer = 1,IsSpring = 0, IsFall = 0},
                     new Credit{CreditID = 555,CreditAbbrev = "555-NS",CreditName = "Network Security",IsSummer = 0,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 691,CreditAbbrev = "691-GDP1",CreditName = "GDP1",IsSummer = 1,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 692,CreditAbbrev = "692-GDP2",CreditName = "GDP2",IsSummer = 0,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 6  ,CreditAbbrev = "MOBILE",CreditName ="643 or 644 Mobile",IsSummer = 0,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 10 ,CreditAbbrev = "E1",CreditName = "Elective1",IsSummer = 0,IsSpring = 1, IsFall = 1},
                     new Credit{CreditID = 20 ,CreditAbbrev = "E2",CreditName = "Elective2",IsSummer = 0,IsSpring = 1, IsFall = 1}
                };
                Console.WriteLine($"Inserted{credits.Length} new students.");
                foreach (Credit s in credits)
                {
                    context.Credits.Add(s);
                }
                context.SaveChanges();
            }

            if (context.DegreeCredit.Any())
            {
                Console.WriteLine("Degreess already exist");
            }
            else
            {
                var DegreeCredits = new DegreeCredit[] {
                new DegreeCredit { DegreeCreditID = 1, DegreeID = 1, CreditID = 560 },
new DegreeCredit { DegreeCreditID = 2, DegreeID = 1, CreditID = 356 },
new DegreeCredit { DegreeCreditID = 3, DegreeID = 1, CreditID = 542 },
new DegreeCredit { DegreeCreditID = 4, DegreeID = 1, CreditID = 563 },
new DegreeCredit { DegreeCreditID = 5, DegreeID = 1, CreditID = 560 },
new DegreeCredit { DegreeCreditID = 6, DegreeID = 1, CreditID = 664 },
new DegreeCredit { DegreeCreditID = 7, DegreeID = 1, CreditID = 618 },
new DegreeCredit { DegreeCreditID = 8, DegreeID = 1, CreditID = 555 },
new DegreeCredit { DegreeCreditID = 9, DegreeID = 1, CreditID = 691 },
new DegreeCredit { DegreeCreditID = 10, DegreeID = 1, CreditID = 692 },
new DegreeCredit { DegreeCreditID = 11, DegreeID = 1, CreditID = 6 },
new DegreeCredit { DegreeCreditID = 12, DegreeID = 1, CreditID = 10 },
new DegreeCredit { DegreeCreditID = 13, DegreeID = 1, CreditID = 20 },
new DegreeCredit { DegreeCreditID = 14, DegreeID = 2, CreditID = 560 },
new DegreeCredit { DegreeCreditID = 15, DegreeID = 2, CreditID = 542 },
new DegreeCredit { DegreeCreditID = 16, DegreeID = 2, CreditID = 563 },
new DegreeCredit { DegreeCreditID = 17, DegreeID = 2, CreditID = 560 },
new DegreeCredit { DegreeCreditID = 18, DegreeID = 2, CreditID = 664 },
new DegreeCredit { DegreeCreditID = 19, DegreeID = 2, CreditID = 618 },
new DegreeCredit { DegreeCreditID = 20, DegreeID = 2, CreditID = 555 },
new DegreeCredit { DegreeCreditID = 21, DegreeID = 2, CreditID = 691 },
new DegreeCredit { DegreeCreditID = 22, DegreeID = 2, CreditID = 692 },
new DegreeCredit { DegreeCreditID = 23, DegreeID = 2, CreditID = 6 },
new DegreeCredit { DegreeCreditID = 24, DegreeID = 2, CreditID = 10 },
new DegreeCredit { DegreeCreditID = 25, DegreeID = 2, CreditID = 20 },
new DegreeCredit { DegreeCreditID = 26, DegreeID = 3, CreditID = 356 },
new DegreeCredit { DegreeCreditID = 27, DegreeID = 3, CreditID = 542 },
new DegreeCredit { DegreeCreditID = 28, DegreeID = 3, CreditID = 563 },
new DegreeCredit { DegreeCreditID = 29, DegreeID = 3, CreditID = 560 },
new DegreeCredit { DegreeCreditID = 30, DegreeID = 3, CreditID = 664 },
new DegreeCredit { DegreeCreditID = 31, DegreeID = 3, CreditID = 618 },
new DegreeCredit { DegreeCreditID = 32, DegreeID = 3, CreditID = 555 },
new DegreeCredit { DegreeCreditID = 33, DegreeID = 3, CreditID = 691 },
new DegreeCredit { DegreeCreditID = 34, DegreeID = 3, CreditID = 692 },
new DegreeCredit { DegreeCreditID = 35, DegreeID = 3, CreditID = 6 },
new DegreeCredit { DegreeCreditID = 36, DegreeID = 3, CreditID = 10 },
new DegreeCredit { DegreeCreditID = 37, DegreeID = 3, CreditID = 20 },
new DegreeCredit { DegreeCreditID = 38, DegreeID = 4, CreditID = 542 },
new DegreeCredit { DegreeCreditID = 39, DegreeID = 4, CreditID = 563 },
new DegreeCredit { DegreeCreditID = 40, DegreeID = 4, CreditID = 560 },
new DegreeCredit { DegreeCreditID = 41, DegreeID = 4, CreditID = 664 },
new DegreeCredit { DegreeCreditID = 42, DegreeID = 4, CreditID = 618 },
new DegreeCredit { DegreeCreditID = 43, DegreeID = 4, CreditID = 555 },
new DegreeCredit { DegreeCreditID = 44, DegreeID = 4, CreditID = 691 },
new DegreeCredit { DegreeCreditID = 45, DegreeID = 4, CreditID = 692 },
new DegreeCredit { DegreeCreditID = 46, DegreeID = 4, CreditID = 6 },
new DegreeCredit { DegreeCreditID = 47, DegreeID = 4, CreditID = 10 },
new DegreeCredit { DegreeCreditID = 48, DegreeID = 4, CreditID = 20 },

};


                Console.WriteLine($"Inserted{DegreeCredits.Length} new students.");
                foreach (DegreeCredit De in DegreeCredits)
                {
                    context.DegreeCredit.Add(De);
                }
                context.SaveChanges();

            }

            if (context.Students.Any())
            {
                Console.WriteLine("Students already exist");
            }
            else
            {
                var students = new Student[] {
                    new Student{StudentID =533491,LastName = "Pasham",FirstName = "Goutami",I919 = 919564044},
                    new Student{StudentID =533705,LastName = "Adusumalli",FirstName = "Gangadhar",I919 = 919570593},
                    new Student{StudentID =533988,LastName = "Singam",FirstName = "Poojitha",I919 = 919571721},
                    new Student{StudentID =533622,LastName = "Gattu",FirstName = "Srujana",I919 = 919569251},
                    new Student{StudentID =533727,LastName = "Poshala",FirstName = "Himabindu",I919 = 919571930}
                };
                Console.WriteLine($"Inserted{students.Length} new students.");
                foreach (Student s in students)
                {
                    context.Students.Add(s);
                }
                context.SaveChanges();
            }

            if (context.DegreePlans.Any())
            {
                Console.WriteLine("DegreePlans already exist");
            }
            else
            {
                var degreeplans = new DegreePlan[] {

new DegreePlan{DegreePlanID=7253,StudentID=533705,DegreePlanAbbrev="Super fast",DegreePlanName="As fast as I can",DegreeID=3},
new DegreePlan{DegreePlanID=7254,StudentID=533705,DegreePlanAbbrev="slow And Easy",DegreePlanName="Take a summer Off",DegreeID=3},
new DegreePlan{DegreePlanID=7255,StudentID=533491,DegreePlanAbbrev="Super fast",DegreePlanName="As fast as I can",DegreeID=3},
new DegreePlan{DegreePlanID=7256,StudentID=533491,DegreePlanAbbrev="slow And Easy",DegreePlanName="Take a summer Off",DegreeID=3},
new DegreePlan{DegreePlanID=7257,StudentID=533727,DegreePlanAbbrev="SuperFast",DegreePlanName="As fast as I can",DegreeID=3},
new DegreePlan{DegreePlanID=7258,StudentID=533727,DegreePlanAbbrev="slow And Easy",DegreePlanName="Take a summer Off",DegreeID=3},
new DegreePlan{DegreePlanID=7259,StudentID=533622,DegreePlanAbbrev="slow And Easy",DegreePlanName="Take a summer Off",DegreeID=3},
new DegreePlan{DegreePlanID=7260,StudentID=533622,DegreePlanAbbrev="slow And Easy",DegreePlanName="Take a summer Off",DegreeID=3},
new DegreePlan{DegreePlanID=7261,StudentID=533988,DegreePlanAbbrev="Super fast",DegreePlanName="As fast as I can",DegreeID=3},
new DegreePlan{DegreePlanID=7262,StudentID=533988,DegreePlanAbbrev="slow And Easy",DegreePlanName="Take a summer Off",DegreeID=3},


                };
                Console.WriteLine($"Inserted{degreeplans.Length} new students.");
                foreach (DegreePlan s in degreeplans)
                {
                    context.DegreePlans.Add(s);
                }
                context.SaveChanges();
            }

            if (context.StudentTerms.Any())
            {
                Console.WriteLine("Degreess already exist");
            }
            else
            {
                var studentterms = new StudentTerm[] {
new StudentTerm{StudentTermID=1,DegreePlanId=7255,Term=1,TermAbbrev="F18",TermName="Fall2018"},
new StudentTerm{StudentTermID=2,DegreePlanId=7255,Term=2,TermAbbrev="S19",TermName="Spring2019"},
new StudentTerm{StudentTermID=3,DegreePlanId=7255,Term=3,TermAbbrev="Sum",TermName="Summer2019"},
new StudentTerm{StudentTermID=4,DegreePlanId=7255,Term=4,TermAbbrev="F19",TermName="Fall2019"},
new StudentTerm{StudentTermID=5,DegreePlanId=7256,Term=1,TermAbbrev="F18",TermName="Fall2018"},
new StudentTerm{StudentTermID=6,DegreePlanId=7256,Term=2,TermAbbrev="S19",TermName="Spring2019"},
new StudentTerm{StudentTermID=7,DegreePlanId=7256,Term=3,TermAbbrev="F19",TermName="Fall2019"},
new StudentTerm{StudentTermID=8,DegreePlanId=7256,Term=4,TermAbbrev="S20",TermName="Spring2020"},
new StudentTerm{StudentTermID=9,DegreePlanId=7261,Term=1,TermAbbrev="F19",TermName="Fall2019"},
new StudentTerm{StudentTermID=10,DegreePlanId=7261,Term=2,TermAbbrev="S20",TermName="SPRING2020"},
new StudentTerm{StudentTermID=11,DegreePlanId=7261,Term=3,TermAbbrev="SU20",TermName="SUMMER2020"},
new StudentTerm{StudentTermID=12,DegreePlanId=7261,Term=4,TermAbbrev="F20",TermName="Fall2020"},
new StudentTerm{StudentTermID=13,DegreePlanId=7262,Term=1,TermAbbrev="F19",TermName="FALL2019"},
new StudentTerm{StudentTermID=14,DegreePlanId=7262,Term=2,TermAbbrev="S20",TermName="SPRING2020"},
new StudentTerm{StudentTermID=15,DegreePlanId=7262,Term=3,TermAbbrev="SU20",TermName="SUMMER2020"},
new StudentTerm{StudentTermID=16,DegreePlanId=7262,Term=4,TermAbbrev="F20",TermName="FALL2020"},
new StudentTerm{StudentTermID=17,DegreePlanId=7262,Term=5,TermAbbrev="S21",TermName="SPRING2021"},
new StudentTerm{StudentTermID=18,DegreePlanId=7259,Term=1,TermAbbrev="F18",TermName="FALL2018"},
new StudentTerm{StudentTermID=19,DegreePlanId=7259,Term=2,TermAbbrev="S19",TermName="Spring2019"},
new StudentTerm{StudentTermID=20,DegreePlanId=7259,Term=3,TermAbbrev="Sum19",TermName="Summer2019"},
new StudentTerm{StudentTermID=21,DegreePlanId=7259,Term=4,TermAbbrev="F19",TermName="Fall2019"},
new StudentTerm{StudentTermID=22,DegreePlanId=7259,Term=5,TermAbbrev="S20",TermName="Spring2020"},
new StudentTerm{StudentTermID=23,DegreePlanId=7260,Term=1,TermAbbrev="F18",TermName="FALL2018"},
new StudentTerm{StudentTermID=24,DegreePlanId=7260,Term=2,TermAbbrev="S19",TermName="Spring2019"},
new StudentTerm{StudentTermID=25,DegreePlanId=7260,Term=3,TermAbbrev="F19",TermName="Fall2019"},
new StudentTerm{StudentTermID=26,DegreePlanId=7260,Term=4,TermAbbrev="S20",TermName="Spring2020"},
new StudentTerm{StudentTermID=27,DegreePlanId=7260,Term=5,TermAbbrev="Sum20",TermName="Summer2020"},
new StudentTerm{StudentTermID=28,DegreePlanId=7257,Term=1,TermAbbrev="F18",TermName="FALL2018"},
new StudentTerm{StudentTermID=29,DegreePlanId=7257,Term=2,TermAbbrev="S19",TermName="Spring2019"},
new StudentTerm{StudentTermID=30,DegreePlanId=7257,Term=3,TermAbbrev="Sum19",TermName="Summer2019"},
new StudentTerm{StudentTermID=31,DegreePlanId=7257,Term=4,TermAbbrev="F19",TermName="Fall2019"},
new StudentTerm{StudentTermID=32,DegreePlanId=7258,Term=1,TermAbbrev="F18",TermName="FALL2018"},
new StudentTerm{StudentTermID=33,DegreePlanId=7258,Term=2,TermAbbrev="S19",TermName="Spring2019"},
new StudentTerm{StudentTermID=34,DegreePlanId=7258,Term=3,TermAbbrev="F19",TermName="Fall2019"},
new StudentTerm{StudentTermID=35,DegreePlanId=7258,Term=4,TermAbbrev="S20",TermName="Spring2020"},
new StudentTerm{StudentTermID=36,DegreePlanId=7258,Term=5,TermAbbrev="Sum20",TermName="Summer2020"},
new StudentTerm{StudentTermID=37,DegreePlanId=7253,Term=1,TermAbbrev="F 2018",TermName="Fall 2018"},
new StudentTerm{StudentTermID=38,DegreePlanId=7253,Term=2,TermAbbrev="S19",TermName="Spring 2019"},
new StudentTerm{StudentTermID=39,DegreePlanId=7253,Term=3,TermAbbrev="Sum19",TermName="Summer 2019"},
new StudentTerm{StudentTermID=40,DegreePlanId=7253,Term=4,TermAbbrev="F19",TermName="Fall 2019"},
new StudentTerm{StudentTermID=41,DegreePlanId=7254,Term=1,TermAbbrev="S19",TermName="Spring 2019"},
new StudentTerm{StudentTermID=42,DegreePlanId=7254,Term=2,TermAbbrev="F19",TermName="Fall 2019"},
new StudentTerm{StudentTermID=43,DegreePlanId=7254,Term=3,TermAbbrev="S20",TermName="Spring 2020"},
new StudentTerm{StudentTermID=44,DegreePlanId=7254,Term=4,TermAbbrev="Sum20",TermName="Summer 2020"},
new StudentTerm{StudentTermID=45,DegreePlanId=7254,Term=5,TermAbbrev="F20",TermName="Fall 2020"},

                };
                Console.WriteLine($"Inserted{studentterms.Length} new students.");
                foreach (StudentTerm s in studentterms)
                {
                    context.StudentTerms.Add(s);
                }
                context.SaveChanges();
            }

            if (context.Slots.Any())
            {
                Console.WriteLine("Slots already exist");
            }
            else
            {
                var slots = new Slot[] {
 new Slot{SlotID=1,StudentTermID=1,Term=1,DegreeCreditID=26,Status ='B'},
new Slot{SlotID=2,StudentTermID=1,Term=1,DegreeCreditID=27,Status ='B'},
new Slot{SlotID=3,StudentTermID=1,Term=1,DegreeCreditID=28,Status ='C'},
new Slot{SlotID=4,StudentTermID=1,Term=2,DegreeCreditID=29,Status ='C'},
new Slot{SlotID=5,StudentTermID=2,Term=2,DegreeCreditID=35,Status ='B'},
new Slot{SlotID=6,StudentTermID=2,Term=2,DegreeCreditID=36,Status ='B'},
new Slot{SlotID=7,StudentTermID=2,Term=3,DegreeCreditID=30,Status ='B'},
new Slot{SlotID=8,StudentTermID=3,Term=3,DegreeCreditID=36,Status ='B'},
new Slot{SlotID=9,StudentTermID=3,Term=3,DegreeCreditID=31,Status ='B'},
new Slot{SlotID=10,StudentTermID=3,Term=4,DegreeCreditID=33,Status ='B'},
new Slot{SlotID=11,StudentTermID=4,Term=4,DegreeCreditID=37,Status ='B'},
new Slot{SlotID=12,StudentTermID=4,Term=4,DegreeCreditID=43,Status ='B'},
new Slot{SlotID=13,StudentTermID=13,Term=1,DegreeCreditID=13,Status ='B'},
new Slot{SlotID=14,StudentTermID=14,Term=1,DegreeCreditID=14,Status ='B'},
new Slot{SlotID=15,StudentTermID=15,Term=1,DegreeCreditID=15,Status ='B'},
new Slot{SlotID=16,StudentTermID=16,Term=2,DegreeCreditID=16,Status ='B'},
new Slot{SlotID=17,StudentTermID=17,Term=2,DegreeCreditID=17,Status ='B'},
new Slot{SlotID=18,StudentTermID=18,Term=2,DegreeCreditID=18,Status ='B'},
new Slot{SlotID=19,StudentTermID=19,Term=3,DegreeCreditID=19,Status ='B'},
new Slot{SlotID=20,StudentTermID=20,Term=3,DegreeCreditID=20,Status ='B'},
new Slot{SlotID=21,StudentTermID=21,Term=3,DegreeCreditID=21,Status ='B'},
new Slot{SlotID=22,StudentTermID=22,Term=4,DegreeCreditID=22,Status ='B'},
new Slot{SlotID=23,StudentTermID=23,Term=4,DegreeCreditID=23,Status ='B'},
new Slot{SlotID=24,StudentTermID=24,Term=4,DegreeCreditID=24,Status ='B'},
new Slot{SlotID=25,StudentTermID=25,Term=1,DegreeCreditID=25,Status ='B'},
new Slot{SlotID=26,StudentTermID=26,Term=1,DegreeCreditID=26,Status ='B'},
new Slot{SlotID=27,StudentTermID=27,Term=1,DegreeCreditID=27,Status ='C'},
new Slot{SlotID=28,StudentTermID=28,Term=2,DegreeCreditID=28,Status ='C'},
new Slot{SlotID=29,StudentTermID=29,Term=2,DegreeCreditID=29,Status ='A'},
new Slot{SlotID=30,StudentTermID=30,Term=2,DegreeCreditID=30,Status ='A'},
new Slot{SlotID=31,StudentTermID=31,Term=3,DegreeCreditID=31,Status ='A'},
new Slot{SlotID=32,StudentTermID=32,Term=4,DegreeCreditID=23,Status ='A'},
new Slot{SlotID=33,StudentTermID=33,Term=4,DegreeCreditID=20,Status ='A'},
new Slot{SlotID=34,StudentTermID=34,Term=5,DegreeCreditID=23,Status ='A'},
new Slot{SlotID=35,StudentTermID=35,Term=5,DegreeCreditID=24,Status ='A'},
new Slot{SlotID=36,StudentTermID=36,Term=5,DegreeCreditID=25,Status ='A'},
new Slot{SlotID=37,StudentTermID=37,Term=1,DegreeCreditID=45,Status ='A'},
new Slot{SlotID=38,StudentTermID=38,Term=1,DegreeCreditID=44,Status ='A'},
new Slot{SlotID=39,StudentTermID=39,Term=1,DegreeCreditID=12,Status ='A'},
new Slot{SlotID=40,StudentTermID=40,Term=2,DegreeCreditID=19,Status ='A'},
new Slot{SlotID=41,StudentTermID=41,Term=2,DegreeCreditID=21,Status ='A'},
new Slot{SlotID=42,StudentTermID=42,Term=2,DegreeCreditID=6,Status ='A'},
new Slot{SlotID=43,StudentTermID=43,Term=4,DegreeCreditID=7,Status ='A'},
new Slot{SlotID=44,StudentTermID=44,Term=4,DegreeCreditID=20,Status ='A'},
new Slot{SlotID=45,StudentTermID=45,Term=5,DegreeCreditID=9,Status ='A'},


                };
                Console.WriteLine($"Inserted{slots.Length} new slots.");
                foreach (Slot s in slots)
                {
                    context.Slots.Add(s);
                }
                context.SaveChanges();
            }


            if (context.Developers.Any())
            {
                Console.WriteLine("Developers already exist");
            }
            else
            {
                var developers = new Developers[] {
                    
                };
                Console.WriteLine($"Inserted{developers.Length} new students.");
                foreach (Developers s in developers)
                {
                    context.Developers.Add(s);
                }
                context.SaveChanges();
            }
        }
    }
}


        

    

