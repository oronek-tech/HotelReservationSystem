using Caliburn.Micro;
using HotelReservationSystem.Models;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelReservationSystem.ViewModels
{
    class AddReservationViewModel : Screen
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


        
                
       

        public AddReservationViewModel()
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

        public bool CanSavePerson(string selectedFirstName,string selectedLastName, string selectedMail, string selectedPhoneNumber)
        {
            if (String.IsNullOrWhiteSpace(selectedFirstName) || string.IsNullOrWhiteSpace(selectedLastName) || string.IsNullOrWhiteSpace(selectedMail) || string.IsNullOrWhiteSpace(selectedPhoneNumber))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void SavePerson(string selectedFirstName, string selectedLastName, string selectedMail, string selectedPhoneNumber)
        {
            var contextSave = new HotelReservationBaseEntities1();
            contextSave.People.Add(new Person
            {
                FirstName = SelectedFirstName,
                LastName = SelectedLastName,
                Mail = SelectedMail,
                PhoneNumber = SelectedPhoneNumber

            });
            contextSave.SaveChanges();

        }


        
        public void SaveReservation()
        {
            if( (SelectedRoom !=null) && (SelectedPerson != null) && (SelectedDateIn<SelectedDateOut) && (SelectedDateIn!=null) && (SelectedDateOut!=null))
            {
                var contextSave = new HotelReservationBaseEntities1();
                contextSave.Reservations.Add(new Reservation
                {
                    IdNumber = SelectedRoom.IdNumber,
                    IdOsoby = SelectedPerson.IdOsoby,
                    InDate = SelectedDateIn,
                    OutDate = SelectedDateOut,
                    NumberOfGuest = SelectedNumberOfGuest
                });
                contextSave.SaveChanges();
            }
            else
            {
                MessageBox.Show("Brak danych","Uwaga!!!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


    }
}
