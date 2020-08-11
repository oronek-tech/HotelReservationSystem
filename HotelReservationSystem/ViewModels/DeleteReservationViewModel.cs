using Caliburn.Micro;
using HotelReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelReservationSystem.ViewModels
{
    class DeleteReservationViewModel : Screen
    {

        private BindableCollection<Person> _peopleList;
        private Person _selectedPerson;

        private BindableCollection<Room> _roomsList;
        private Room _selectedRoom;

        private BindableCollection<Reservation> _reservationsList;
        private Reservation _selectedReservation;

        private DateTime _selectedDateIn = DateTime.Now;
        private DateTime _selectedDateOut = DateTime.Now;
        private int _selectedNumberOfGuest;
        private string _selectedFirstName;
        private string _selectedLastName;
        private string _selectedMail;
        private string _selectedPhoneNumber;

        public DeleteReservationViewModel()
        {
            var context = new HotelReservationBaseEntities1();
            PeopleList = new BindableCollection<Person>(context.People);
            RoomsList = new BindableCollection<Room>(context.Rooms);
            ReservationsList = new BindableCollection<Reservation>(context.Reservations);




        }
        public BindableCollection<Person> PeopleList { get; set; }


        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public BindableCollection<Room> RoomsList { get; set; }

        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                NotifyOfPropertyChange(() => SelectedRoom);
            }
        }

        public BindableCollection<Reservation> ReservationsList { get; set; }

        public Reservation SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                _selectedReservation = value;
                NotifyOfPropertyChange(() => SelectedReservation);
            }
        }


        public DateTime SelectedDateIn
        {
            get { return _selectedDateIn; }
            set
            {
                _selectedDateIn = value;
                NotifyOfPropertyChange(() => SelectedDateIn);
            }
        }
        public DateTime SelectedDateOut
        {
            get { return _selectedDateOut; }
            set
            {
                _selectedDateOut = value;
                NotifyOfPropertyChange(() => SelectedDateOut);
            }
        }

        public int SelectedNumberOfGuest
        {
            get { return _selectedNumberOfGuest; }
            set
            {
                _selectedNumberOfGuest = value;
                NotifyOfPropertyChange(() => SelectedNumberOfGuest);
            }
        }
        public string SelectedFirstName
        {
            get { return _selectedFirstName; }
            set
            {
                _selectedFirstName = value;
                NotifyOfPropertyChange(() => SelectedFirstName);
            }
        }
        public string SelectedLastName
        {
            get { return _selectedLastName; }
            set
            {
                _selectedLastName = value;
                NotifyOfPropertyChange(() => SelectedLastName);
            }
        }

        public string SelectedMail
        {
            get { return _selectedMail; }
            set
            {
                _selectedMail = value;
                NotifyOfPropertyChange(() => SelectedMail);
            }
        }

        public string SelectedPhoneNumber
        {
            get { return _selectedPhoneNumber; }
            set
            {
                _selectedPhoneNumber = value;
                NotifyOfPropertyChange(() => SelectedPhoneNumber);
            }
        }


        public void DeleteReservation()
        {
            if (SelectedReservation != null)
            {
                var contextDelete = new HotelReservationBaseEntities1();
                var dane = contextDelete.Reservations.Find(SelectedReservation.IdReservation);
                contextDelete.Reservations.Remove(dane);
                contextDelete.SaveChanges();

            }


            else
            {
                MessageBox.Show("Nie wybrana rezerwacja do usunięcia", "Uwaga!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void SaveEditReservation()
        {
            var contextEdit = new HotelReservationBaseEntities1();
            var dane = contextEdit.Reservations.Find(SelectedReservation.IdReservation);
            contextEdit.Reservations.Remove(dane);
            contextEdit.SaveChanges();
            contextEdit.Reservations.Add(new Reservation
            {
                IdReservation = SelectedReservation.IdReservation,
                IdNumber = SelectedReservation.IdNumber,
                IdOsoby = SelectedPerson.IdOsoby,
                InDate = SelectedDateIn,
                OutDate = SelectedDateOut,
                NumberOfGuest = SelectedNumberOfGuest

            });
            contextEdit.SaveChanges();
            NotifyOfPropertyChange(() => ReservationsList);



        }

        public void EditReservation()
        {
            SelectedRoom = SelectedReservation.Room;
            SelectedPerson = SelectedReservation.Person;
            SelectedDateIn = SelectedReservation.InDate;
            SelectedDateOut = SelectedReservation.OutDate;
            SelectedNumberOfGuest = SelectedReservation.NumberOfGuest;
        }
    }
}
