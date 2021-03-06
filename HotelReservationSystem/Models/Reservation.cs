//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelReservationSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int IdReservation { get; set; }
        public int IdNumber { get; set; }
        public int IdOsoby { get; set; }
        public System.DateTime InDate { get; set; }
        public System.DateTime OutDate { get; set; }
        public int NumberOfGuest { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Room Room { get; set; }

        public string ReservationInformation
        {
            get
            {
                return $"{ Person.FullName }, Pok�j: { Room.RoomInformation }, Data przyjazdu: { InDate }, Data wyjazdu: { OutDate }, Liczba go�ci: { NumberOfGuest }";
            }
        }
    }
}
