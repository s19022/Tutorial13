using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_13.DTOs.Request;
using Tutorial_13.DTOs.Responce;
using Tutorial_13.Exceptions;
using Tutorial_13.Models;

namespace Tutorial_13.Services
{
    public class MsSqlOrderDbService : IOrderDbService
    {
        private OrderDbContext _context;

        public MsSqlOrderDbService(OrderDbContext context)
        {
            _context = context;
        }

        public List<GetOrdersResponce> GetListOfOrders(GetOrdersRequest request)
        {
            string name = request.Name;

            if (name != null)
            {
                int count = _context.Customer.Where(cust => cust.Name == name).Count();
                if (count == 0) throw new NoSuchCustomerException("No customer found with name " + name);
            }

            if (name == null) name = "";

            return _context.Order.Join(_context.Confectionery_Order,
                order => order.IdOrder,
                con_order => con_order.IdOrder,
                (order, con_order) => new GetOrdersResponce()
                {
                    IdOrder = order.IdOrder,
                    DateAccepted = order.DateAccepted,
                    DateFinished = order.DateFinished,
                    Notes = order.Notes,
                    IdCustomer = order.IdCustomer,
                    IdConfectionery = con_order.IdConfectionary
                }).Where(resp => _context.Customer.Where(customer => customer.Name.Contains(name)).Select(cust => cust.IdCustomer)
                .Contains(resp.IdCustomer)).ToList();
        }

        public AddOrderResponce AddOrder(int idCustomer, AddOrderRequest request)
        {
            AddOrderResponce responce = new AddOrderResponce()
            {
                Conf_Ids = new List<int>()
            };



            int countUserId = _context.Customer.Where(c => c.IdCustomer == idCustomer).Count();
            if (countUserId != 1) throw new NoSuchCustomerException("No customer with id " + idCustomer + " found");

            foreach (AddConfectioneryRequest item in request.Confectionery)
            {
                if (_context.Confectionery.Select(conf => conf.Name).Where(n => n == item.Name).Count() != 1)
                    throw new NoSuchConfectioneryException("No conf with name \"" + item.Name + "\" found");
            }


            using (var trans = _context.Database.BeginTransaction())
            {
                Order order = new Order()
                {
                    DateAccepted = request.DateAccepted,
                    Notes = request.Notes,
                    IdCustomer = idCustomer,
                    IdEmployee = request.IdEmployee
                };

                _context.Add<Order>(order);

                _context.SaveChanges();


                responce.IdOrder = order.IdOrder;



                foreach (AddConfectioneryRequest item in request.Confectionery)
                {
                    int id = _context.Confectionery.Where(conf => conf.Name == item.Name).Select(conf => conf.IdConfectionery).FirstOrDefault();
                    
                    responce.Conf_Ids.Add(id);
                   
                    _context.Add<Confectionery_Order>(new Confectionery_Order()
                    {
                        IdConfectionary = id,
                        IdOrder = order.IdOrder,
                        Quantity = item.Quantity,
                        Notes = item.Notes
                    });
                }

                _context.SaveChanges();

                trans.Commit();

            }

            return responce;
        }

    }
}
