using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class TicketFileParser
    {
        private StreamReader _reader;
        private List<Ticket> _tickets;

        public TicketFileParser(StreamReader reader)
        {
            _reader = reader;
            _tickets = new List<Ticket>();
        }

        private void FindTicketsInLine(string ticketsString)
        {
            List<string> ticketsList = (ticketsString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)).ToList();
            for (int i = 0; i < ticketsList.Count; i++)
            {
                if ((ticketsList[i].Length % 2 != 0) || (!int.TryParse(ticketsList[i], out _)))
                {
                    ticketsList.RemoveAt(i);
                    i--;
                }
                else
                {
                    _tickets.Add(new Ticket(ticketsList[i]));
                }
            }
        }

        public List<Ticket> GetTickets()
        {
            string line = string.Empty;

            using (_reader)
            {
                while ((line = _reader.ReadLine()) != null)
                {
                    FindTicketsInLine(line);
                }
            }

            return _tickets;
        }
    }
}
