using Reserva.Entities;
using Reserva.Entities.Exceptions;

namespace Reserva
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room numer");
                int num = int.Parse(Console.ReadLine());
                Console.Write("data de entrada: ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("data de saida: ");
                DateTime checkOut= DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(num, checkIn, checkOut);
                Console.WriteLine("Reserva: "+ reservation);
                
                Console.WriteLine();
                Console.WriteLine("Entre com nova data");
                Console.Write("data de entrada: ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("data de saida: ");
                checkOut = DateTime.Parse(Console.ReadLine());
                
                reservation.UpdateDates(checkIn, checkOut);

                Console.WriteLine("Reserva: " + reservation);      
            }
            catch(DomainException e)
            {
                Console.WriteLine("Erro na reserva: "+e.Message);
            }  
            catch(FormatException e)
            {
                Console.WriteLine("Erro no formato: "+e.Message);
            }       
            catch(Exception e)
            {
                Console.WriteLine("Erro inesperado: "+e.Message);
            }
        }
    }
}