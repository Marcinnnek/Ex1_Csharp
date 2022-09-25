using Ex1_Csharp;
namespace Ex1_Csharp_Tests
{
    public class ShapesTests
    {
        [Fact]
        public void CirclePerimeter()
        {
            //arrange
            double pa = 10;
            var expected = 2 * Math.PI * pa;

            Circle circle = new Circle(pa);

            //act
            var result = circle.CalculatePerimeter();

            //assert
            Assert.Equal(result, expected);
        }



        [Fact]
        public void CircleArea()
        {
            //arrange
            double pa = 10;
            var expected = Math.PI * Math.Pow(pa, 2);

            Circle circle = new Circle(pa);

            //act
            var result = circle.CalculateArea();

            //assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void RectanglePerimeter()
        {
            //arrange
            double pa = 12;
            double pb = 45;
            var expected = 2 * pa + 2 * pb;

            Rectangle rectangle = new Rectangle(pa, pb);

            //act
            var result = rectangle.CalculatePerimeter();

            //assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void RectangleArea()
        {
            //arrange
            double pa = 12;
            double pb = 45;

            var expected = pa * pb;

            Rectangle rectangle = new Rectangle(pa, pb);

            //act
            var result = rectangle.CalculateArea();

            //assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void TrianglePerimeter()
        {
            //arrange
            double pa = 10;
            double pb = 20;
            double pc = 30;
            var expected = pa + pb + pc;

            Triangle triangle = new Triangle(pa, pb, pc);

            //act
            var result = triangle.CalculatePerimeter();

            //assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void TrianlgeArea()
        {
            //arrange
            double pa = 10;
            double pb = 20;
            double pc = 30;
            var expected = ((pa + pb) * pc) / 2;

            Triangle triangle = new Triangle(pa, pb, pc);

            //act
            var result = triangle.CalculateArea();

            //assert
            Assert.Equal(result, expected);
        }


        [Fact]
        public void SetParameterACircleTest()
        {
            //arrange
            double pa = -5;

            string newValue = "30";
            var stringReader = new StringReader(newValue);
            Console.SetIn(stringReader);

            //act
            Circle circle = new Circle(pa);

            //assert
            Assert.Equal(circle.A, double.Parse(newValue));
        }

        [Fact]
        public void SetParameterBRectangleTest()
        {
            //arrange
            double pa = 25;
            double pb = -33;

            string newValue = "30";
            var stringReader = new StringReader(newValue);
            Console.SetIn(stringReader);

            //act
            Rectangle rectangle = new Rectangle(pa, pb);

            //assert
            Assert.Equal(rectangle.B, double.Parse(newValue));
        }

        [Fact]
        public void SetParameterCTriangleTest()
        {
            //arrange
            double pa = 25;
            double pb = 20;
            double pc = 0;

            string newValue = "30";
            var stringReader = new StringReader(newValue);
            Console.SetIn(stringReader);

            //act
            Triangle triangle = new Triangle(pa, pb, pc);

            //assert
            Assert.Equal(triangle.C, double.Parse(newValue));
        }

        [Fact]
        public void CircleGetInfoTest()
        {
            //arrange
            double pa = 25;
            var expectedValue = "a = 25, area = 1963,50, preimeter = 157,08";
            Circle circle = new Circle(pa);

            //act
            var currentValue = circle.GetInfo();

            //assert
            Assert.Equal(currentValue, expectedValue);
        }

        [Fact]
        public void RectangleGetInfoTest()
        {
            //arrange
            double pa = 23;
            double pb = 33;
            var expectedValue = "a = 23 ,b = 33, area = 759,00, preimeter = 112,00";
            Rectangle rectangle = new Rectangle(pa, pb);

            //act
            var currentValue = rectangle.GetInfo();

            //assert
            Assert.Equal(currentValue, expectedValue);
        }

        [Fact]
        public void TriangleGetInfoTest()
        {
            //arrange
            double pa = 12;
            double pb = 5;
            double pc = 10;
            var expectedValue = "a = 12 ,b = 5, c = 10, area = 85,00, preimeter = 27,00";
            Triangle triangle = new Triangle(pa, pb, pc);

            //act
            var currentValue = triangle.GetInfo();

            //assert
            Assert.Equal(currentValue, expectedValue);
        }

    }
}