using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Application.Features.Products.Commands.CreateProduct;
using Tekton.Application.Features.Products.Commands.UpdateProduct;
using Tekton.Dominio;

namespace Tekton.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>(); 
        }
    }
}
