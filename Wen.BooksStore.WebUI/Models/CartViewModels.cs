using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }
    }
}