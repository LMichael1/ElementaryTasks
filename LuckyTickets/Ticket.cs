using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class Ticket
    {
        #region Properties

        public byte[] Number { get; private set; }
        public bool IsLucky { get; set; } 
        public int Length
        {
            get => Number.Length;
        }

        #endregion

        public byte this[int index]
        {
            get
            {
                if (index < Number.Length)
                {
                    return Number[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public Ticket(string number)
        {
            Number = StringToByteArray(number);
            IsLucky = false;
        }

        private byte[] StringToByteArray(string number)
        {
            byte[] ticketsArray = new byte[number.Length];

            for (int i = 0; i < number.Length; i++)
            {
                ticketsArray[i] = byte.Parse(Convert.ToString(number[i]));
            }

            return ticketsArray;
        }
    }
}
