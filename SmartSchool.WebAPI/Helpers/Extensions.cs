﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmartSchool.WebAPI.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response,
            int currentPage, int itemPerPage, int totalItems, int totalPages)
        {   
            var paginationHeader = new PaginationHeader(currentPage, itemPerPage, totalItems, totalPages);

            var camelCaseFormatter = new JsonSerializerSettings();

            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Accss-Control-Expose-Header","Pagination");
        }   
    }
}
