using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.DTOs.OrderItemDTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Service.OrderItemService;
using System.Diagnostics;

namespace OrderManagementSystem.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService service;
        private readonly ILogger<OrderItemController> _logger;

        public OrderItemController(ILogger<OrderItemController> logger, IOrderItemService service)
        {
            this.service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var orderItems = await service.GetOrderItemsAsync();
            return View(orderItems);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateOrderItem(OrderItemDTO updatedOrderItem)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    errorMessage = "Invalid data",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                await service.UpdateOrderItemAsync(updatedOrderItem);
                return Json(new { success = true });  // Return a success response
            }
            catch (Exception ex)
            {
                // If there's an error, return a failure response with the error message
                return Json(new { success = false, errorMessage = ex.Message });
            }

        }
        [HttpDelete]
        public async Task<JsonResult> DeleteOrderItem(int id)
        {
            try
            {
                await service.DeleteOrderItemByIdAsync(id);
                return Json(new { success = true });  // Return a success response
            }
            catch (Exception ex)
            {
                // If there's an error, return a failure response with the error message
                return Json(new { success = false, errorMessage = ex.Message });
            }

        }
        [HttpPost]
        public async Task<JsonResult> InsertOrder(InsertOrderItemDTO insertOrderItemDTO)
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
                var updatedOrderItem = await service.InsertOrderItemAsync(insertOrderItemDTO);
                return Json(new { success = true, order = updatedOrderItem }); ;  // Return a success response
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
