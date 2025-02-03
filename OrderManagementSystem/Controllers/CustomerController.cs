using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.DTOs.CustomerDTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Service.CustomerSer;
using System.Diagnostics;

namespace OrderManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomerService service;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customer = await service.GetCustomersAsync();  // Fetch all persons from the database
            return View(customer);  // Pass the list of persons to the view
        }
        
        [HttpGet]
        public async Task<IActionResult> CustomersOrders() {

            IEnumerable<CustomersOrderDTO> customersOrders = await service.GetCustomersOrdersAsync();  // Fetch all persons from the database
            return View(customersOrders);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateCustomer(CustomerDTO updatedCustomer) 
        {
            if (!ModelState.IsValid) {
                return Json(new { success = false, errorMessage = "Invalid data", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }
            try { 
                            
                await service.UpdateCustomerAsync(updatedCustomer);
                return Json(new { success = true });  // Return a success response
            }
            catch (Exception ex)
            {
                // If there's an error, return a failure response with the error message
                return Json(new { success = false, errorMessage = ex.Message });
            }
           
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteCustomer(int id)
        {
            try
            {
                await service.DeleteCustomerByIdAsync(id);
                return Json(new { success = true });  // Return a success response
            }
            catch (Exception ex)
            {
                // If there's an error, return a failure response with the error message
                return Json(new { success = false, errorMessage = ex.Message });
            }

        }
        [HttpPost]
        public async Task<JsonResult> InsertCustomer(InsertCustomerDTO insertCustomerDTO)
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
               var updatedCustomer = await service.InsertCustomerAsync(insertCustomerDTO);
               return Json(new { success = true,customer = updatedCustomer });;  // Return a success response
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
