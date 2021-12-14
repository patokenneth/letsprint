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
            //implemented for test purpose
            if (!Enum.IsDefined(typeof(ProductType), name))
            {
                throw new NotImplementedException();
            }

            switch (name)
            {
                case ProductType.PhotoBook:
                    return 19 * quantity;
                   
                case ProductType.Calendar:
                    return 10 * quantity;
                   
                case ProductType.Canvas:
                    return 16 * quantity;
                    
                case ProductType.Cards:
                    return 4.7 * quantity;
                    
                case ProductType.Mug:
                    return 94 * Math.Ceiling((Double)quantity/4);
                default:
                    break;
            }

            return Double.NaN;
        }
    }
}
