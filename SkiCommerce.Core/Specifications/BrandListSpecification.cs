using System;
using SkiCommerce.Core.Entities;

namespace SkiCommerce.Core.Specifications;

public class BrandListSpecification : BaseSpecification<Product, string>
{
    public BrandListSpecification()
    {
        AddSelect(x=> x.Brand);
        ApplyDistinct();
    }
}
