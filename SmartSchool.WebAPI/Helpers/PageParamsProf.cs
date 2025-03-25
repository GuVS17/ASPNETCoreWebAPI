using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Helpers
{
    public class PageParamsProf
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get{return pageSize; }
            set{ pageSize = (value > MaxPageSize) ? MaxPageSize : value;}    //Se a quantidade de itens por página for maior que o MaxPageSize, vai retornar só 50
        }

        public int? Registro { get; set; } = null;
        public string Nome { get; set; } = string.Empty;
        public int? Ativo { get; set; } = null;
    }
}