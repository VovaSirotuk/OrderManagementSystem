using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.DTOs.OrderDTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Service.OrderService;
using System.Diagnostics;

namespace OrderManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService service;
        private readonly ILogger<HomeController> _logger;

        public OrderController(ILogger<HomeController> logger, IOrderService service)
        {
            this.service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await service.GetOrdersAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateOrder(OrderDTO updatedOrder)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { 
                    success = false, 
                    errorMessage = "Invalid data", 
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }
            try
            {
                await service.UpdateOrderAsync(updatedOrder);
                return Json(new { success = true });  // Return a success response
            }
            catch (Exception ex)
            {
                // If there's an error, return a failure response with the error message
                return Json(new { success = false, errorMessage = ex.Message });
            }

        }
        [HttpDelete]
        public async Task<JsonResult> DeleteOrder(int id)
        {
            try
            {
                await service.DeleteOrderByIdAsync(id);
                return Json(new { success = true });  // Return a success response
            }
            catch (Exception ex)
            {
                // If there's an error, return a failure response with the error message
                return Json(new { success = false, errorMessage = ex.Message });
            }

        }
        [HttpPost]
        public async Task<JsonResult> InsertOrder(InsertOrderDTO insertOrderDTO)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                var updatedOrder= await service.InsertOrderAsync(insertOrderDTO);
                return Json(new { success = true, order = updatedOrder }); ;  // Return a success response
            }
            catch (Exception ex)
            {
                // If there's an error, return a failure response with the error message
                return Json(new { success = false, errorMessage = ex.Message });
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
