using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappChatParser
{
    public class Person : IComparable, IEquatable<Person>
    {
        private string name;
        private List<Message> sentMessages;

        public Person(string name)
        {
            this.name = name;
            sentMessages = new List<Message>();
        }

        public void AddNewMessage(Message newMsg)
        {
            sentMessages.Add(newMsg);
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int CompareTo(object obj)
        {
            Person otherPerson = (Person)obj;

            return String.Compare(this.Name, otherPerson.Name);
        }

        public bool Equals(Person other)
        {
            if (other != null && other.Name == this.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Message> Messages
        {
            get
            {
                return sentMessages;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
