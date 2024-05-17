using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen
{
    public class Customer
    {
        private string name;
        private string phonenumber;
        private string email;

        public Customer(string name, string email, string phonenumber)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phonenumber) || string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidDataException("Invalid Input");
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new InvalidDataException("Invalid email address.");
            }
            else
            {
                foreach (char c in name)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        throw new InvalidDataException("Invalid name");
                    }
                }
            }
            foreach (char c in phonenumber)
            {
                if (!char.IsDigit(c) && c != '-' && c != '+')
                {
                    throw new InvalidDataException("Invalid phonenumber");
                }
                    
            }
            Name = name;
            Email = email;
            Phonenumber = phonenumber;


        }

        public string Name
        { get { return name; } set { name = value; } }
        public string Phonenumber
        { get { return phonenumber; } set { phonenumber = value; } }
        public string Email
        { get { return email; } set { email = value; } }

    }
}
