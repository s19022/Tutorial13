using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_13.DTOs.Request;
using Tutorial_13.DTOs.Responce;

namespace Tutorial_13.Services
{
    public interface IOrderDbService
    {
        public List<GetOrdersResponce> GetListOfOrders(GetOrdersRequest request);

        public AddOrderResponce AddOrder(int idCustomer, AddOrderRequest request);


    }
}
