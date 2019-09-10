using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class MoscowAlgorithm : ILuckyTicketAlgorithm
    {
        #region Fields

        private List<Ticket> _ticketsList;

        #endregion

        public MoscowAlgorithm(List<Ticket> ticketsList)
        {
            _ticketsList = ticketsList;
            FindLucky();
        }

        public int GetNumberOfLuckyTickets()
        {
            int numberOfLuckyTickets = 0;

            for (int i = 0; i < _ticketsList.Count; i++)
            {
                if (_ticketsList[i].IsLucky)
                {
                    numberOfLuckyTickets++;
                }
            }

            return numberOfLuckyTickets;
        }

        private void FindLucky()
        {
            for (int i = 0; i < _ticketsList.Count; i++)
            {
                int result = 0;

                for (int j = 0; j < _ticketsList[i].Length / 2; j++)
                {
                    result -= _ticketsList[i][j];
                }

                for (int j = _ticketsList[i].Length / 2; j < _ticketsList[i].Length; j++)
                {
                    result += _ticketsList[i][j];
                }

                if (result == 0)
                {
                    _ticketsList[i].IsLucky = true;
                }
            }
        }
    }
}
