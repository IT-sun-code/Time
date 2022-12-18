using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimeLibrary;

namespace TimeTest
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod] //Тест на введение значения < 0 для часов
        public void Set_Hours_With_Value_Less_Than_Zero_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            int Hours = -1;
            TimeClass time = new TimeClass();

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => time.Hours = Hours);
        }

        [TestMethod] //Тест на введение значения > 23 для часов
        public void Set_Hours_With_Value_Greater_Than_Twenty_Three_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            int Hours = 24;
            TimeClass time = new TimeClass();

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => time.Hours = Hours);
        }

        [TestMethod] //Тест на введение значения < 0 для минут
        public void Set_Minutes_With_Value_Less_Than_Zero_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            int Minutes = -2;
            TimeClass time = new TimeClass();

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => time.Minutes = Minutes);
        }

        [TestMethod] //Тест на введение значения >= 60 для минут
        public void Set_Minutes_With_Value_Greater_Than_Or_Equal_To_Sixty_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            int Minutes = 60;
            TimeClass time = new TimeClass();

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => time.Minutes = Minutes);
        }

        [TestMethod] //Тест на введение значения < 0 для cекунд
        public void Set_Seconds_With_Value_Less_Than_Zero_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            int Seconds = -10;
            TimeClass time = new TimeClass();

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => time.Seconds = Seconds);
        }

        [TestMethod] //Тест на введение значения >= 60 для cекунд
        public void Set_Seconds_With_Value_Greater_Than_Or_Equal_To_Sixty_Should_Throw_ArgumentOutOfRangeException()
        {
            //Arrange
            int Seconds = 70;
            TimeClass time = new TimeClass();

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => time.Seconds = Seconds);
        }

        [TestMethod] //Тест для функции ToString()
        public void Input_With_Valid_Value_To_String()
        {
            //Arrange
            int Hours = 22;
            int Minutes = 30;
            int Seconds = 15;
            string expected = $"22:30:15";
            TimeClass time = new TimeClass();

            //Act
            time.Hours = Hours;
            time.Minutes = Minutes;
            time.Seconds = Seconds;
            string actual = time.ToString();

            //Assert
            Assert.AreEqual(expected, actual, "Conversion to a string value failed");
        }

        [TestMethod] //Тест для вычисления разницы между двумя моментами времени в секундах
        public void Time_With_Valid_Value_Get_Time_Difference()
        {
            //Arrange
            int Hours1 = 17;
            int Minutes1 = 30;
            int Seconds1 = 10;
            int Hours2 = 18;
            int Minutes2 = 30;
            int Seconds2 = 10;
            int expected = 3600;
            TimeClass time1 = new TimeClass(Hours1, Minutes1, Seconds1);
            TimeClass time2 = new TimeClass(Hours2, Minutes2, Seconds2);

            //Act
            int actual = time1.GetTimeDifference(time2);

            //Assert
            Assert.AreEqual(expected, actual, "Failed to subtract from one time another");
        }

        [TestMethod]
        public void Operator_Overload_Time_Not_Equals(){
            //Arrange
            TimeClass a = new TimeClass(12, 0, 0);
            TimeClass b = new TimeClass(14, 0, 0);

            //Assert
            Assert.IsTrue(a != b, "Fail. Time equals");
        }

        #region - Time Tests Not Equals -
        /*
        [TestMethod]
        public void Time_Not_Equals_Minutes()
        {
            TimeClass a = new TimeClass(14, 30, 0);
            TimeClass b = new TimeClass(14, 0, 0);

            Assert.IsTrue(a != b, "Fail. Minutes equals");
        }

        [TestMethod]
        public void Time_Not_Equals_Seconds()
        {
            TimeClass a = new TimeClass(14, 30, 20);
            TimeClass b = new TimeClass(14, 30, 0);

            Assert.IsTrue(a != b, "Fail. Seconds equals");
        }
        */
        #endregion


        [TestMethod]
        public void Operator_Overload_Time_Equals()
        {
            //Arrange
            TimeClass a = new TimeClass(14, 30, 20);
            TimeClass b = new TimeClass(14, 30, 20);

            //Assert
            Assert.IsTrue(a == b, "Fail. Time not equals");
        }

        #region - Time Tests Equals -
        /*
        [TestMethod]
        public void Time_Equals_Minutes()
        {
            TimeClass a = new TimeClass(14, 30, 0);
            TimeClass b = new TimeClass(14, 30, 0);

            Assert.IsTrue(a == b, "Fail. Minutes not equals");
        }

        [TestMethod]
        public void Time_Equals_Seconds()
        {
            TimeClass a = new TimeClass(14, 30, 20);
            TimeClass b = new TimeClass(14, 30, 20);

            Assert.IsTrue(a == b, "Fail. Seconds not equals");
        }
        */

        #endregion

        [TestMethod]
        public void Operator_Overload_Time_Lower()
        {
            //Arrange
            TimeClass a = new TimeClass(14, 30, 18);
            TimeClass b = new TimeClass(14, 30, 19);

            //Assert
            Assert.IsTrue(a < b, "Fail. Time equal or greater");
        }

        [TestMethod]
        public void Operator_Overload_Time_Greater()
        {
            //Arrange
            TimeClass a = new TimeClass(14, 30, 20);
            TimeClass b = new TimeClass(14, 30, 19);

            //Assert
            Assert.IsTrue(a > b, "Fail. Time equal or lower");
        }

        [TestMethod]
        public void Operator_Overload_Time_Lower_Or_Equal()
        {
            //Arrange
            TimeClass a = new TimeClass(14, 30, 17);
            TimeClass b = new TimeClass(14, 30, 18);
            //Assert
            Assert.IsTrue(a <= b, "Fail. Time greater (1)");

            //Arrange
            a = new TimeClass(14, 30, 18);
            //Assert
            Assert.IsTrue(a <= b, "Fail. Time greater (2)");
        }

        [TestMethod]
        public void Operator_Overload_Time_Greater_Or_Equal()
        {
            //Arrange
            TimeClass a = new TimeClass(14, 30, 20);
            TimeClass b = new TimeClass(14, 30, 19);
            //Assert
            Assert.IsTrue(a >= b, "Fail. Time lower (1)");

            //Arrange
            a = new TimeClass(14, 30, 19);
            //Assert
            Assert.IsTrue(a >= b, "Fail. Time lower (2)");
        }

        [TestMethod]
        public void Operator_Overload_Time_Overload_Substract()
        {
            // TODO: AreEqual Выдает ошибку при совпадении данных 
            // Странная работа AreEqauls
            // (Ожидаемое: <23:0:0> Фактическое: <23:0:0>)

            //Arrange
            var a = new TimeClass(0, 0, 0);
            var b = new TimeClass(1, 0, 0);
            var expected = new TimeClass(23, 0, 0);
            //Act
            var actual = a - b;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to subtract from one time another (Hours)");

            //Arrange
            a = new TimeClass(0, 0, 0);
            b = new TimeClass(0, 1, 0);
            expected = new TimeClass(23, 59, 0);
            //Act
            actual = a - b;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to subtract from one time another (Minutes)");

            //Arrange
            a = new TimeClass(0, 0, 0);
            b = new TimeClass(0, 0, 1);
            expected = new TimeClass(23, 59, 59);
            //Act
            actual = a - b;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to subtract from one time another (Seconds)");
        }

        [TestMethod]
        public void Operator_Overload_Time_Increment()
        {
            //Arrange
            var a = new TimeClass(23, 59, 59);
            var expected = new TimeClass(0, 0, 0);
            //Act
            var actual = ++a;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to increment (1)");

            //Arrange
            a = new TimeClass(22, 59, 59);
            expected = new TimeClass(23, 0, 0);
            //Act
            actual = ++a;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to increment (2)");

            //Arrange
            a = new TimeClass(0, 0, 0);
            expected = new TimeClass(0, 0, 1);
            //Act
            actual = ++a;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to increment (3)");
        }

        [TestMethod]
        public void Operator_Overload_Time_Decrement()
        {
            //Arrange
            var a = new TimeClass(0, 0, 0);
            var expected = new TimeClass(23, 59, 59);
            //Act
            var actual = --a;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to decrement (1)");

            //Arrange
            a = new TimeClass(22, 0, 0);
            expected = new TimeClass(21, 59, 59);
            //Act
            actual = --a;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to decrement (2)");

            //Arrange
            a = new TimeClass(0, 0, 1);
            expected = new TimeClass(0, 0, 0);
            //Act
            actual = --a;
            //Assert
            Assert.IsTrue(expected == actual, "Failed to decrement (3)");
        }

        [TestMethod]
        public void Operator_Overload_Time_True()
        {
            //Arrange
            var a = new TimeClass(0, 0, 0);
            //Act
            bool actual = a ? true : false;
            //Assert
            Assert.IsTrue(actual, "Failed. It's false");
        }

        [TestMethod]
        public void Operator_Overload_Time_False()
        {
            //Arrange
            var a = new TimeClass(1, 1, 1);
            //Act
            bool actual = a ? true : false;
            //Assert
            Assert.IsFalse(actual, "Failed. It's false");
        }

    }
}