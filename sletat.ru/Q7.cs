using sletat.ru.HotelServiceReference;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace sletat.ru
{
    public class HotelDataService
    {
        private readonly IHotelService hotelServiceClient;

        public HotelDataService(IHotelService hotelServiceClient)
        {
            this.hotelServiceClient = hotelServiceClient;
        }
       
        public async Task<IEnumerable<Hotel>> GetHotels(IEnumerable<int> hotelIds)
        {
            IList<Hotel> hotels = new List<Hotel>();

            IEnumerable<Task<Hotel>> tasks =
                from id in hotelIds select hotelServiceClient.GetHotelAsync(id);

            List<Task<Hotel>> runningTasks = tasks.ToList();

            while (runningTasks.Count > 0)
            {
                Task<Hotel> completedTask = await Task.WhenAny(runningTasks);
                runningTasks.Remove(completedTask);
                                 
                Hotel hotel = await completedTask;
                hotels.Add(hotel);
            }

            return hotels;
        }
    }
}
