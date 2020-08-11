using Caliburn.Micro;
using HotelReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.ViewModels
{
    class ReservationListViewModel : Screen
    {
        public BindableCollection<Reservation> ReservationsList { get; set; }
        //public BindableCollection<Room> RoomsReserved { get; set; }

        public ReservationListViewModel()
        {
            var context = new HotelReservationBaseEntities1();
            ReservationsList = new BindableCollection<Reservation>(context.Reservations);
            //RoomsReserved = new BindableCollection<Room>(context.Reservations.Join(context.Rooms, c => c.IdNumber, a => a.IdNumber, (Reservation, Room) => Room));
            //var RoomsReserved = context.Reservations.Join(context.Rooms, c => c.IdNumber, a => a.IdNumber, (Reservation, Room) => Room);
            //var pokój = new Room();

        }


    }
}
