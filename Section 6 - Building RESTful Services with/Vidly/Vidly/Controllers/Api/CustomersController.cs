using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        // Initialize DB context
        private ApplicationDbContext _context;



        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // ############################ To test Mapper, these were commented #####################################

        /*
           // Get all customer list [GET /api/customers]
           // This code commented because of mapper testing.
            public IEnumerable<Customer> GetCustomers()
            {
                return _context.Customers.ToList();
            }
        */



        /* 
             // Get single customer using ID [GET /api/customers/1]
             // This code commented because of mapper testing.
             public Customer GetCustomer(int id)
             {
                 var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

                 if (customer == null)
                     throw new HttpResponseException(HttpStatusCode.NotFound);

                 return customer;
             }
        */


        /*
             * This code commented because of mapper testing.
             * Create new resource to customer [POST /api/customers]
             * We can apply POST method in two ways
                  1. Using [HttpPost] annotation. (Best option)
                  2. Using PostCustomer() method.

            [HttpPost]
            public Customer CreateCustomer(Customer customer)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                // Add customer
                _context.Customers.Add(customer);

                // Save changes
                _context.SaveChanges();

                return customer;
            }
        */



        /*
            // Update customer for given ID[PUT / api / customers / 1]
            // In here, we can update a customer or void. Therefore, we use void to do both action
            // This code commented because of mapper testing.
            [HttpPut]
            public void UpdateCustomer(int id, Customer customer)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

                _context.SaveChanges();
            }
        */


        // ############################ To test IHttpAction, these were commented #####################################

        /*
            // Get all customer list [GET /api/customers]
            // Call mapper class.
            public IEnumerable<CustomerDto> GetCustomers()
            {
                return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            }




            // Get single customer using ID [GET /api/customers/1]
            // Call mapper class.
            public CustomerDto GetCustomer(int id)
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customer == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                return Mapper.Map<Customer, CustomerDto>(customer);
            }



            *//*
               * Create new resource to customer [POST /api/customers]
               * We can apply POST method in two ways
                   1. Using [HttpPost] annotation. (Best option)
                   2. Using PostCustomer() method.

               * Call mapper class.
            *//*
            [HttpPost]
            public CustomerDto CreateCustomer(CustomerDto customerDto)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

                // Add customer
                _context.Customers.Add(customer);

                // Save changes
                _context.SaveChanges();

                customerDto.Id = customer.Id;

                return customerDto;
            }



            // Update customer for given ID [PUT /api/customers/1]
            // In here, we can update a customer or void. Therefore, we use void to do both action
            // Call mapper class.
            [HttpPut]
            public void UpdateCustomer(int id, CustomerDto customerDto)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                Mapper.Map(customerDto, customerInDb);

                _context.SaveChanges();
            }


            // Delete customer for given ID [DELETE /api/customers/1]
            // In here, we can delete a customer or void. Therefore, we use void to do both action
            [HttpDelete]
            public void DeleteCustomer(int id)
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }
        */


        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }



        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }



        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }



        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }




        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
