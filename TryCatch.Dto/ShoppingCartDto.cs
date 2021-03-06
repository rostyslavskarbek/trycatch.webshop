﻿using System.Collections.Generic;

namespace TryCatch.Dto
{
    public class ShoppingCartDto
    {
        public ShoppingCartDto()
        {
            ArticleIds = new List<string>();
        }

        public string ShoppingCartId { get; set; }
        public List<string> ArticleIds { get; set; }
    }
}
