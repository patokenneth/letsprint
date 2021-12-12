using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.Utility
{
    public class WidthCalculator
    {
        public static double CalculateWidth(ProductType name, int quantity)
        {
            switch (name)
            {
                case ProductType.photoBook:
                    return 19 * quantity;
                   
                case ProductType.calendar:
                    return 10 * quantity;
                   
                case ProductType.canvas:
                    return 16 * quantity;
                    
                case ProductType.cards:
                    return 4.7 * quantity;
                    
                case ProductType.mug:
                    return 94 * Math.Ceiling((Double)quantity/4);
                default:
                    break;
            }

            return Double.NaN;
        }
    }
}
