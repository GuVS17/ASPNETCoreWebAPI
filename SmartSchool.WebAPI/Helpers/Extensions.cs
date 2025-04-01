using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmartSchool.WebAPI.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response,
            int currentPage, 
            int itemsPerPage,
            int totalItems, 
            int totalPages) 
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages );

            var CamelCaseFormatter = new JsonSerializerSettings();
            CamelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, CamelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}