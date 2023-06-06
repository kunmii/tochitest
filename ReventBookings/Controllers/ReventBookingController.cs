using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReventBookings.Data;
using ReventBookings.Model;

namespace ReventBookings.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReventBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public ReventBookingController(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This part handles creating a new booking
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(ReventBooking booking)
        {
            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                return new JsonResult(BadRequest());
            }

            _context.SaveChanges();

            return new JsonResult(Ok(booking));

        }

        /// <summary>
        /// This part handles Viewing an existing booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult View(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        /// <summary>
        /// This part handles editing an existing booking
        /// </summary>
        /// <param name="id"></param>
        /// <param name="booking"></param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult Update(int id, ReventBooking booking)
        {
            if (id != booking.Id)
                return new JsonResult (BadRequest());

            _context.Bookings.Update(booking);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        /// <summary>
        /// This part handles deleting an existing booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }



        /// <summary>
        /// This part handles getting all existing bookings. It will be commented out as it is not part of the required endpoints.
        /// </summary>
        /// <returns></returns>
        //[HttpGet()]
        //public JsonResult GetAll()
        //{
        //    var result = _context.Bookings.ToList();

        //    return new JsonResult(Ok(result));
        //}
    }
}
