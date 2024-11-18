using Reserva.Entities.Exceptions;

namespace Reserva.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation(){}
        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut){
            if(checkIn <= checkOut)
            {
                throw new DomainException("Error na reserva, Datas muito proximas");
            }
            
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
        public int Duration(){
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }
        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;

            if(checkIn < now || checkOut < now)
            {
                throw new DomainException("Erro na reserva, data invalida");
            }
            if(checkIn <= checkOut)
            {
                throw new DomainException("Error na reserva, Datas muito proximas");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
        }
        public override string ToString()
        {
            return "Room: " + RoomNumber +", check-in: " + CheckIn.ToString("d/MM/yy") + ", check-out: " + CheckOut.ToString("dd/MM/yy") + ", " + Duration() + "nights";
        }
    }
}