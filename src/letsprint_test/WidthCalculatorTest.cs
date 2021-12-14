using letsprint.Utility;
using System;
using Xunit;

namespace letsprint_test
{
    public class WidthCalculatorTest
    {
        [Fact]
        public void WidthCalculator_Returns_RequiredBinWidth()
        {
            //Arrange
            var producttype = ProductType.mug;
            var quantity = 9;

            //Act
            var requiredBinWidth = WidthCalculator.CalculateWidth(producttype, quantity);

            //Assert
            Assert.Equal(282, requiredBinWidth);
            
        }

        [Fact]
        public void WidthCalculator_ReturnsZero_When_QuantityisZero()
        {
            //Arrange
            var producttype = ProductType.photoBook;
            var quantity = 0;

            //Act
            var requiredBinWidth = WidthCalculator.CalculateWidth(producttype, quantity);

            //Assert
            Assert.True(requiredBinWidth == 0, "BinWidth is zero when quantity is zero");
        }

        [Fact]
        public void WidthCalculator_ThrowsException_forUnimplemented_ProductType()
        {
            //Arrange
            var producttype = (ProductType)5;
            var quantity = 3;

            
            //Assert
            Assert.Throws<NotImplementedException>(() => WidthCalculator.CalculateWidth(producttype, quantity));
        }
    }
}
