using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Helpers;
public static class DiscountHelper
{
    public static decimal? GetDiscountedPrice(decimal originalPrice, IEnumerable<Domain.Discount> discounts)
    {
        if (discounts != null && discounts.Any())
        {
            decimal discountedPrice = originalPrice;

            foreach (var discount in discounts)
            {
                if (discount.StartAt <= DateTime.Now && discount.EndAt >= DateTime.Now)
                {
                    discountedPrice *= (1 - (discount.Percent / 100));
                }
            }

            return Math.Round(discountedPrice, 2);
        }

        return null;
    }
}

