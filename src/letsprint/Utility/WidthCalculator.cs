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
            //implemented for test purpose since this case is already taken care of in the repository
            if (!Enum.IsDefined(typeof(ProductType), name))
            {
                throw new NotImplementedException();
            }

            double binwidth = 0;

            switch (name)
            {
                case ProductType.photoBook:
                    binwidth = 19 * quantity;
                    break;
                case ProductType.calendar:
                    binwidth = 10 * quantity;
                    break;
                case ProductType.canvas:
                    binwidth = 16 * quantity;
                    break;
                case ProductType.cards:
                    binwidth = 4.7 * quantity;
                    break;
                case ProductType.mug:
                    binwidth = 94 * Math.Ceiling((Double)quantity/4);
                    break;
                default:
                    break;
            }

            return Math.Round(binwidth, 2);
        }
    }
}
