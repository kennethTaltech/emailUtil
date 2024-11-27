

namespace EX_10_1
{
    public class EmailUtility
    {
        public static void Main(string[] args) { }

        private string _email = string.Empty;

        // Method to store email
        public void AddEmail(string email)
        {
            _email = email;
        }

        // Returns stored email in uppercase
        public string GetCapitalizedEmail()
        {
            return _email.ToUpper();
        }

        // Method to return the length of the email
        public int GetEmailLength()
        {
            return _email.Length;
        }

        // Method to check if the email contains a specified domain
        public bool ContainsDomain(string domain)
        {
            return _email.Contains(domain);
        }

        // Method to get the name part from the email
        public string GetNameFromEmail()
        {
            int atIndex = _email.IndexOf('@');
            return atIndex >= 0 ? _email.Substring(0, atIndex) : string.Empty;
        }

        public bool IsValidEmail()
        {
            if (string.IsNullOrEmpty(_email))
                return false;

            int atIndex = _email.IndexOf('@');
            int dotIndex = _email.LastIndexOf('.');

            // Check if exactly one '@', and it is not the first or last character
            if (atIndex <= 0 || atIndex != _email.LastIndexOf('@') || atIndex == _email.Length - 1)
                return false;

            // Check if domain contains a dot and is at least 3 characters from the '@'
            if (dotIndex < atIndex + 3 || dotIndex == _email.Length - 1)
                return false;

            // Name and domain part minimum length
            string namePart = _email.Substring(0, atIndex);
            string domainPart = _email.Substring(atIndex + 1);

            if (namePart.Length < 1 || domainPart.Length < 3)
                return false;

            return true;
        }

        public string CreateEmail(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return string.Empty;

            string email = $"{firstName[0]}{lastName.Substring(0, Math.Min(5, lastName.Length))}@taltech.ee";
            return email.ToLower(); // return in lowercase
        }

        public string ChangeDomain(string newDomain)
        {
            if (string.IsNullOrEmpty(_email) || !IsValidEmail())
                return string.Empty;

            int atIndex = _email.IndexOf('@');
            return _email.Substring(0, atIndex + 1) + newDomain;
        }


    }
}
