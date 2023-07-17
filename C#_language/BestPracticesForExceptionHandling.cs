

namespace UserRegistration
{
    public class UserRegistrationException : Exception
    {
        public UserRegistrationException(string message) : base(message)
        {
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public User(string username, string email, int age)
        {
            Username = username;
            Email = email;
            Age = age;
        }
    }

    public class UserRegistrationSystem
    {
        public void RegisterUser(string username, string email, int age)
        {
            try
            {
                ValidateRegistrationData(username, email, age);
                CreateUser(username, email, age);
                Console.WriteLine("User registration successful.");
            }
            catch (ArgumentNullException ex)
            {
                LogExceptionDetails(ex, "One or more registration fields are missing.");
                Console.WriteLine("User registration failed: One or more registration fields are missing.");
            }
            catch (FormatException ex)
            {
                LogExceptionDetails(ex, "Invalid format in registration fields.");
                Console.WriteLine("User registration failed: Invalid format in registration fields.");
            }
            catch (UserRegistrationException ex)
            {
                LogExceptionDetails(ex, "Registration validation rule failed.");
                Console.WriteLine($"User registration failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                LogExceptionDetails(ex, "An error occurred during user registration.");
                Console.WriteLine("User registration failed: An unexpected error occurred.");
            }
        }

        private void ValidateRegistrationData(string username, string email, int age)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (age <= 0)
            {
                throw new UserRegistrationException("Age must be a positive value.");
            }
        }

        private void CreateUser(string username, string email, int age)
        {
            User newUser = new User(username, email, age);
        }

        private void LogExceptionDetails(Exception ex, string errorMessage)
        {
            Console.WriteLine($"Exception: {ex.GetType().Name}");
            Console.WriteLine($"Error Message: {errorMessage}");
            Console.WriteLine($"Stack Trace:\n{ex.StackTrace}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserRegistrationSystem registrationSystem = new UserRegistrationSystem();

            // User registration 
            string validUsername = "Ravi";
            string invalidUsername = null;
            string validEmail = "ravi@example.com";
            string invalidEmail = "invalidemail";
            int validAge = 25;
            int invalidAge = -5;

            registrationSystem.RegisterUser(validUsername, validEmail, validAge);
            Console.WriteLine();

            registrationSystem.RegisterUser(invalidUsername, validEmail, validAge);
            Console.WriteLine();

            registrationSystem.RegisterUser(validUsername, invalidEmail, validAge);
            Console.WriteLine();

            registrationSystem.RegisterUser(validUsername, validEmail, invalidAge);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
