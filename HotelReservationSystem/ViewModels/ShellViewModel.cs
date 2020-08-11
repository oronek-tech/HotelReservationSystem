using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItem(new ReservationListViewModel());

        }


        public void ReservationList()
        {
            ActivateItem(new ReservationListViewModel());
        }
        public void AddReservation()
        {
            ActivateItem(new AddReservationViewModel());
        }
        public void DeleteReservation()
        {
            ActivateItem(new DeleteReservationViewModel());
        }
       
    }
}
