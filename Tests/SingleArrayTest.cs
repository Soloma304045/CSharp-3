using System;
using Library;
using Xunit;

namespace Tests
{
    public class SingleArrayTests
    {
        [Fact]
        public void ConstructorTest()
        {
            double[] testArray = new double[] {1, 2, 3};
            SingleArray singleArray = new SingleArray(testArray);
            
            Assert.Equal(1.0, singleArray.GetNumber(0));
            Assert.Equal(2.0, singleArray.GetNumber(1));
            Assert.Equal(3.0, singleArray.GetNumber(2));
        }

        [Fact]
        public void SetNumberTest()
        {
            double[] testArray = new double[] {1, 2, 3};
            SingleArray singleArray = new SingleArray(testArray);
            singleArray.SetNumber(1, 5);
            Assert.Equal(5, singleArray.GetNumber(1));
        }

        [Fact]
        public void GetNumberTest()
        {
            double[] testArray = new double[] {1, 2, 3};
            SingleArray singleArray = new SingleArray(testArray);
            double result = singleArray.GetNumber(2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void GetArrayTest()
        {
            double[] testArray = new double[] {1, 2, 3};
            SingleArray singleArray = new SingleArray(testArray);
            double[] clonedArray = singleArray.GetArray();
            clonedArray[0] = 10;
            Assert.Equal(1, singleArray.GetNumber(0));
        }

        [Fact]
        public void CountTest_1()
        {
            double[] testArray = new double[] {-1, 2, -3, 4};
            SingleArray singleArray = new SingleArray(testArray);
            int count = singleArray.Count();
            Assert.Equal(2, count);
        }

        [Fact]
        public void CountTest_2()
        {
            double[] testArray = new double[] {1, -2, -3, 4};
            SingleArray singleArray = new SingleArray(testArray);
            int count = singleArray.Count(2);
            Assert.Equal(2, count);
        }

        [Fact]
        public void CountTest_3()
        {
            double[] testArray = new double[] {-1, -5, 3, -10};
            SingleArray singleArray = new SingleArray(testArray);
            int count = singleArray.Count(-4.2);
            Assert.Equal(1, count); 
        }

        [Fact]
        public void MulTest_1()
        {
            double[] testArray1 = new double[] {1, 2, 3};
            double[] testArray2 = new double[] {4, 5, 6};
            SingleArray array1 = new SingleArray(testArray1);
            SingleArray array2 = new SingleArray(testArray2);
            SingleArray result = array1 * array2;
            Assert.Equal(4, result.GetNumber(0));
            Assert.Equal(10, result.GetNumber(1));
            Assert.Equal(18, result.GetNumber(2));
        }

        [Fact]
        public void MulTest_2()
        {
            double[] testArray = new double[] {1, 2, 3};
            SingleArray array = new SingleArray(testArray);
            array = array * 2;
            Assert.Equal(1, array.GetNumber(0));
            Assert.Equal(1, array.GetNumber(1));
            Assert.Equal(3, array.GetNumber(2));
        }

        [Fact]
        public void GetNumberErrorTest()
        {
            double[] testArray = {1, 2, 3};
            SingleArray array = new SingleArray(testArray);
            int index = -1;
            var errorMessage = "Value error. Please, try again.";
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                array.GetNumber(index);
                var output = consoleOutput.ToString().Trim();
                Assert.Equal(errorMessage, output);
            }
        }
    }
}
