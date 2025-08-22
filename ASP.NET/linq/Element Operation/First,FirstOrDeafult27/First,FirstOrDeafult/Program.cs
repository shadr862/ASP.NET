namespace First_FirstOrDeafult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var ms=numbers.First();
            var ms1=numbers.Where(x=>x>5).First();
            var ms2 = numbers.First(x => x > 5);
            var ms3 = numbers.FirstOrDefault(x => x > 10);


            List<User> users = new List<User>
            {
                new User { Id = 1, Username = "alice", Password = "pass123" },
                new User { Id = 2, Username = "bob", Password = "secure456" },
                new User { Id = 3, Username = "charlie", Password = "hello789" },
                new User { Id = 4, Username = "david", Password = "mypassword" },
                new User { Id = 5, Username = "eva", Password = "admin2025" }
            };

            var ms4 = users.FirstOrDefault(x => x.Username == "alice" && x.Password == "pass123");
            var mixedS=(from user in users select user).FirstOrDefault(x => x.Username == "alice" && x.Password == "pass123");
        2}
    }
}
