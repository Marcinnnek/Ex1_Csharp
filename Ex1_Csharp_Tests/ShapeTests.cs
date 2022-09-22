using Ex1_Csharp;
namespace Ex1_Csharp_Tests
{
    public class ShapeTests
    {
        [Fact]
        public void TrianglePerimeter()
        {
            double pa = 10;
            double pb = 20;
            double pc = 30;

            Triangle triangle = new Triangle() { a = pa, b = pb, c = pc };
            var result = triangle.CalculatePerimeter();
            var expected = pa+pb+pc;

            Assert.Equal(result, expected);

        }

        [Fact]
        public void TrianlgeArea()
        {
            double pa = 10;
            double pb = 20;
            double pc = 30;

            Triangle triangle = new Triangle() { a = pa, b = pb, c = pc };
            var result = triangle.CalculateArea();
            var expected = ((pa + pb) * pc) / 2;
            
            Assert.Equal(result, expected);

        }
    }
}