using System.Text.Json.Serialization;

namespace ClassroomApi.Model
{
    public class Classroom
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Unique ID for the class
        public string ClassName { get; set; } // Name of the class
        public string Description { get; set; } // Description of the class
        public Guid UserId { get; set; } // ID of the teacher who created the class
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Time of creation

        public string AccessCode { get; set; } = GenerateAccessCode(); // Code used to join the class

        // These properties are ignored when sending JSON to the frontend
        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<Enrollment> Enrollments { get; set; }

        [JsonIgnore]
        public ICollection<Quiz> Quizzes { get; set; }

        [JsonIgnore]
        public ICollection<Assignment> Assignments { get; set; }

        // Function to generate a random 6-letter code (like "A1B2C3")
        public static string GenerateAccessCode()
        {
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] code = new char[6];

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(allowedChars.Length);
                code[i] = allowedChars[index];
            }

            return new string(code); // Example result: "K9L2ME"
        }
    }
}

