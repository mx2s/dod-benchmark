using System;
using System.Collections.Generic;
using DodBenchmark.DOD;
using DodBenchmark.OOP;

namespace DodBenchmark {
    class Program {
        public const string someGuid = "250a360e-8c3a-42e8-9eae-c968ebd2afcd";
        
        public static User[] userArray;

        public static Users users;

        public static double oopDiff;

        public static double dodDiff;
        
        static void Main(string[] args) {
            int amount = 50000;
            
            var usersList = new List<User>();

            for (int i = 0; i < amount; i++) {
                usersList.Add(new User() {
                    id = new Random().Next(),
                    login = "test_login" + new Random().Next(),
                    email = "test_email" + new Random().Next() + "@root.com",
                    guid = null,
                });
            }
            
            userArray = usersList.ToArray();
            users = Users.From(userArray);
            
            TestOOP();
            TestDOD();

            Console.WriteLine("finished.");

            double timesFaster = oopDiff / dodDiff;
            
            Console.WriteLine($"For this benchmark DOD is {timesFaster} times faster!");
        }

        public static void TestOOP() {
            var before = DateTime.Now;

            var currentEmail = "";
            
            for (int i = 0; i < userArray.Length; i++) {
                userArray[i].login = "updatedLogin";
                userArray[i].guid = someGuid;
                currentEmail = userArray[i].email;
            }
            
            oopDiff = (DateTime.Now - before).TotalMilliseconds;
            
            Console.WriteLine("Finished TestOOP");
            Console.WriteLine($"Difference: {oopDiff} ms");
        }

        public static void TestDOD() {
            var before = DateTime.Now;
            
            var currentEmail = "";
            
            for (int i = 0; i < users.ids.Length ;i++) {
                users.logins[i] = "updatedLogin";
                users.guids[i] = someGuid;
                currentEmail = users.emails[i];
            }
            
            dodDiff = (DateTime.Now - before).TotalMilliseconds;
            
            Console.WriteLine("Finished TestDOD");
            Console.WriteLine($"Difference: {dodDiff} ms");
        }
    }
}