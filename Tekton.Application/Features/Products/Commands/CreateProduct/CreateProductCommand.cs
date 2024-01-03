﻿using MediatR; 

namespace Tekton.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    { 
        public string Name { get; set; } = string.Empty;
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
