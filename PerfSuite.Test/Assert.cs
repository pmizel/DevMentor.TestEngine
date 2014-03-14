using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace PerfSuite.Test
{

    public static class Assert
    {
        //internal static EventHandler<EventArgs> AssertionFailure;

        public static void IsTrue(bool condition)
        {
            Assert.IsTrue(condition, string.Empty, null);
        }

        public static void IsTrue(bool condition, string message)
        {
            Assert.IsTrue(condition, message, null);
        }

        public static void IsTrue(bool condition, string message, params object[] parameters)
        {
            if (!condition)
            {
                Assert.HandleFail("Assert.IsTrue", message, parameters);
            }
        }

        public static void IsFalse(bool condition)
        {
            Assert.IsFalse(condition, string.Empty, null);
        }

        public static void IsFalse(bool condition, string message)
        {
            Assert.IsFalse(condition, message, null);
        }

        public static void IsFalse(bool condition, string message, params object[] parameters)
        {
            if (condition)
            {
                Assert.HandleFail("Assert.IsFalse", message, parameters);
            }
        }

        public static void IsNull(object value)
        {
            Assert.IsNull(value, string.Empty, null);
        }

        public static void IsNull(object value, string message)
        {
            Assert.IsNull(value, message, null);
        }

        public static void IsNull(object value, string message, params object[] parameters)
        {
            if (value != null)
            {
                Assert.HandleFail("Assert.IsNull", message, parameters);
            }
        }

        public static void IsNotNull(object value)
        {
            Assert.IsNotNull(value, string.Empty, null);
        }

        public static void IsNotNull(object value, string message)
        {
            Assert.IsNotNull(value, message, null);
        }

        public static void IsNotNull(object value, string message, params object[] parameters)
        {
            if (value == null)
            {
                Assert.HandleFail("Assert.IsNotNull", message, parameters);
            }
        }

        public static void AreSame(object expected, object actual)
        {
            Assert.AreSame(expected, actual, string.Empty, null);
        }

        public static void AreSame(object expected, object actual, string message)
        {
            Assert.AreSame(expected, actual, message, null);
        }

        public static void AreSame(object expected, object actual, string message, params object[] parameters)
        {
            if (!object.ReferenceEquals(expected, actual))
            {
                string message2 = message;
                ValueType valueType = expected as ValueType;
                if (valueType != null)
                {
                    ValueType valueType2 = actual as ValueType;
                    if (valueType2 != null)
                    {
                        message2 = "BothSameElements " + (message == null ? string.Empty : Assert.ReplaceNulls(message));
                    }
                }
                Assert.HandleFail("Assert.AreSame", message2, parameters);
            }
        }

        public static void AreNotSame(object notExpected, object actual)
        {
            Assert.AreNotSame(notExpected, actual, string.Empty, null);
        }

        public static void AreNotSame(object notExpected, object actual, string message)
        {
            Assert.AreNotSame(notExpected, actual, message, null);
        }

        public static void AreNotSame(object notExpected, object actual, string message, params object[] parameters)
        {
            if (object.ReferenceEquals(notExpected, actual))
            {
                Assert.HandleFail("Assert.AreNotSame", message, parameters);
            }
        }

        public static void AreEqual<T>(T expected, T actual)
        {
            Assert.AreEqual<T>(expected, actual, string.Empty, null);
        }

        public static void AreEqual<T>(T expected, T actual, string message)
        {
            Assert.AreEqual<T>(expected, actual, message, null);
        }

        public static void AreEqual<T>(T expected, T actual, string message, params object[] parameters)
        {
            message = Assert.CreateCompleteMessage(message, parameters);
            if (!object.Equals(expected, actual))
            {
                string message2;
                if (actual != null && expected != null && !actual.GetType().Equals(expected.GetType()))
                {
                    message2 = "AreEqualDifferentTypesFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + Assert.ReplaceNulls(expected) + " " + expected.GetType().FullName + " " + Assert.ReplaceNulls(actual) + " " + actual.GetType().FullName);
                }
                else
                {
                    message2 = "AreEqualFailMsg" + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + Assert.ReplaceNulls(expected) + " " + Assert.ReplaceNulls(actual));
                }
                Assert.HandleFailure("Assert.AreEqual", message2);
            }
        }

        public static void AreNotEqual<T>(T notExpected, T actual)
        {
            Assert.AreNotEqual<T>(notExpected, actual, string.Empty, null);
        }

        public static void AreNotEqual<T>(T notExpected, T actual, string message)
        {
            Assert.AreNotEqual<T>(notExpected, actual, message, null);
        }

        public static void AreNotEqual<T>(T notExpected, T actual, string message, params object[] parameters)
        {
            message = Assert.CreateCompleteMessage(message, parameters);
            if (object.Equals(notExpected, actual))
            {
                string message2 = "AreNotEqualFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + Assert.ReplaceNulls(notExpected) + " " + Assert.ReplaceNulls(actual));
                Assert.HandleFailure("Assert.AreNotEqual", message2);
            }
        }

        public static void AreEqual(object expected, object actual)
        {
            Assert.AreEqual(expected, actual, string.Empty, null);
        }

        public static void AreEqual(object expected, object actual, string message)
        {
            Assert.AreEqual(expected, actual, message, null);
        }

        public static void AreEqual(object expected, object actual, string message, params object[] parameters)
        {
            Assert.AreEqual<object>(expected, actual, message, parameters);
        }





        public static void AreNotEqual(object notExpected, object actual)
        {
            Assert.AreNotEqual(notExpected, actual, string.Empty, null);
        }






        public static void AreNotEqual(object notExpected, object actual, string message)
        {
            Assert.AreNotEqual(notExpected, actual, message, null);
        }







        public static void AreNotEqual(object notExpected, object actual, string message, params object[] parameters)
        {
            Assert.AreNotEqual<object>(notExpected, actual, message, parameters);
        }






        public static void AreEqual(float expected, float actual, float delta)
        {
            Assert.AreEqual(expected, actual, delta, string.Empty, null);
        }







        public static void AreEqual(float expected, float actual, float delta, string message)
        {
            Assert.AreEqual(expected, actual, delta, message, null);
        }








        public static void AreEqual(float expected, float actual, float delta, string message, params object[] parameters)
        {
            if (float.IsNaN(expected) || float.IsNaN(actual) || float.IsNaN(delta))
            {
                string message2 = "AreEqualDeltaFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + expected.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + actual.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assert.HandleFail("Assert.AreEqual", message2, parameters);
            }
            if (Math.Abs(expected - actual) > delta)
            {
                string message3 = "AreEqualDeltaFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + expected.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + actual.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assert.HandleFail("Assert.AreEqual", message3, parameters);
            }
        }






        public static void AreNotEqual(float notExpected, float actual, float delta)
        {
            Assert.AreNotEqual(notExpected, actual, delta, string.Empty, null);
        }







        public static void AreNotEqual(float notExpected, float actual, float delta, string message)
        {
            Assert.AreNotEqual(notExpected, actual, delta, message, null);
        }








        public static void AreNotEqual(float notExpected, float actual, float delta, string message, params object[] parameters)
        {
            if (Math.Abs(notExpected - actual) <= delta)
            {
                string message2 = "AreNotEqualDeltaFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + notExpected.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + actual.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assert.HandleFail("Assert.AreNotEqual", message2, parameters);
            }
        }






        public static void AreEqual(double expected, double actual, double delta)
        {
            Assert.AreEqual(expected, actual, delta, string.Empty, null);
        }







        public static void AreEqual(double expected, double actual, double delta, string message)
        {
            Assert.AreEqual(expected, actual, delta, message, null);
        }








        public static void AreEqual(double expected, double actual, double delta, string message, params object[] parameters)
        {
            if (double.IsNaN(expected) || double.IsNaN(actual) || double.IsNaN(delta))
            {
                string message2 = "AreEqualDeltaFailMsg" + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + expected.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + actual.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assert.HandleFail("Assert.AreEqual", message2, parameters);
            }
            if (Math.Abs(expected - actual) > delta)
            {
                string message3 = "AreEqualDeltaFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + expected.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + actual.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assert.HandleFail("Assert.AreEqual", message3, parameters);
            }
        }






        public static void AreNotEqual(double notExpected, double actual, double delta)
        {
            Assert.AreNotEqual(notExpected, actual, delta, string.Empty, null);
        }







        public static void AreNotEqual(double notExpected, double actual, double delta, string message)
        {
            Assert.AreNotEqual(notExpected, actual, delta, message, null);
        }








        public static void AreNotEqual(double notExpected, double actual, double delta, string message, params object[] parameters)
        {
            if (Math.Abs(notExpected - actual) <= delta)
            {
                string message2 = "AreNotEqualDeltaFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + notExpected.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + actual.ToString(CultureInfo.CurrentCulture.NumberFormat) + " " + delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assert.HandleFail("Assert.AreNotEqual", message2, parameters);
            }
        }






        public static void AreEqual(string expected, string actual, bool ignoreCase)
        {
            Assert.AreEqual(expected, actual, ignoreCase, string.Empty, null);
        }







        public static void AreEqual(string expected, string actual, bool ignoreCase, string message)
        {
            Assert.AreEqual(expected, actual, ignoreCase, message, null);
        }








        public static void AreEqual(string expected, string actual, bool ignoreCase, string message, params object[] parameters)
        {
            Assert.AreEqual(expected, actual, ignoreCase, CultureInfo.InvariantCulture, message, parameters);
        }







        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture)
        {
            Assert.AreEqual(expected, actual, ignoreCase, culture, string.Empty, null);
        }








        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message)
        {
            Assert.AreEqual(expected, actual, ignoreCase, culture, message, null);
        }






        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
        {
            Assert.CheckParameterNotNull(culture, "Assert.AreEqual", "culture", string.Empty, new object[0]);
            if (string.Compare(expected, actual, ignoreCase, culture) != 0)
            {
                string message2;
                if (!ignoreCase && string.Compare(expected, actual, true, culture) == 0)
                {
                    message2 = "AreEqualCaseFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + Assert.ReplaceNulls(expected) + " " + Assert.ReplaceNulls(actual));
                }
                else
                {
                    message2 = "AreEqualFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + Assert.ReplaceNulls(expected) + " " + Assert.ReplaceNulls(actual));
                }
                Assert.HandleFail("Assert.AreEqual", message2, parameters);
            }
        }






        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase)
        {
            Assert.AreNotEqual(notExpected, actual, ignoreCase, string.Empty, null);
        }







        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message)
        {
            Assert.AreNotEqual(notExpected, actual, ignoreCase, message, null);
        }








        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message, params object[] parameters)
        {
            Assert.AreNotEqual(notExpected, actual, ignoreCase, CultureInfo.InvariantCulture, message, parameters);
        }







        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture)
        {
            Assert.AreNotEqual(notExpected, actual, ignoreCase, culture, string.Empty, null);
        }








        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message)
        {
            Assert.AreNotEqual(notExpected, actual, ignoreCase, culture, message, null);
        }









        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
        {
            Assert.CheckParameterNotNull(culture, "Assert.AreNotEqual", "culture", string.Empty, new object[0]);
            if (string.Compare(notExpected, actual, ignoreCase, culture) == 0)
            {
                string message2 = "AreNotEqualFailMsg " + (message == null ? string.Empty : Assert.ReplaceNulls(message) + " " + Assert.ReplaceNulls(notExpected) + " " + Assert.ReplaceNulls(actual));
                Assert.HandleFail("Assert.AreNotEqual", message2, parameters);
            }
        }





        public static void IsInstanceOfType(object value, Type expectedType)
        {
            Assert.IsInstanceOfType(value, expectedType, string.Empty, null);
        }






        public static void IsInstanceOfType(object value, Type expectedType, string message)
        {
            Assert.IsInstanceOfType(value, expectedType, message, null);
        }







        public static void IsInstanceOfType(object value, Type expectedType, string message, params object[] parameters)
        {
            if (expectedType == null)
            {
                Assert.HandleFail("Assert.IsInstanceOfType", message, parameters);
            }
            if (!expectedType.IsInstanceOfType(value))
            {
                string message2 = "IsInstanceOfFailMsg " + ((message == null) ? string.Empty : Assert.ReplaceNulls(message) + " " + expectedType.ToString() + " " + ((value == null) ? "Common_NullInMessages" : value.GetType().ToString()));
                Assert.HandleFail("Assert.IsInstanceOfType", message2, parameters);
            }
        }





        public static void IsNotInstanceOfType(object value, Type wrongType)
        {
            Assert.IsNotInstanceOfType(value, wrongType, string.Empty, null);
        }






        public static void IsNotInstanceOfType(object value, Type wrongType, string message)
        {
            Assert.IsNotInstanceOfType(value, wrongType, message, null);
        }







        public static void IsNotInstanceOfType(object value, Type wrongType, string message, params object[] parameters)
        {
            if (wrongType == null)
            {
                Assert.HandleFail("Assert.IsNotInstanceOfType", message, parameters);
            }
            if (value != null && wrongType.IsInstanceOfType(value))
            {
                string message2 = "IsNotInstanceOfFailMsg " + ((message == null) ? string.Empty : Assert.ReplaceNulls(message) + " " + wrongType.ToString() + " " + value.GetType().ToString());
                Assert.HandleFail("Assert.IsNotInstanceOfType", message2, parameters);
            }
        }


        public static void Fail()
        {
            Assert.Fail(string.Empty, null);
        }



        public static void Fail(string message)
        {
            Assert.Fail(message, null);
        }




        public static void Fail(string message, params object[] parameters)
        {
            Assert.HandleFail("Assert.Fail", message, parameters);
        }


        public static void Inconclusive()
        {
            Assert.Inconclusive(string.Empty, null);
        }



        public static void Inconclusive(string message)
        {
            Assert.Inconclusive(message, null);
        }




        public static void Inconclusive(string message, params object[] parameters)
        {
            string param = string.Empty;
            if (!string.IsNullOrEmpty(message))
            {
                if (parameters == null)
                {
                    param = Assert.ReplaceNulls(message);
                }
                else
                {
                    param = string.Format(CultureInfo.CurrentCulture, Assert.ReplaceNulls(message), parameters);
                }
            }
            throw new AssertInconclusiveException("Assert.Inconclusive <" + param + ">");
        }



        public new static bool Equals(object objA, object objB)
        {
            Assert.Fail("DoNotUseAssertEquals");
            return false;
        }
        internal static void HandleFail(string assertionName, string message, params object[] parameters)
        {
            string message2 = Assert.CreateCompleteMessage(message, parameters);
            Assert.HandleFailure(assertionName, message2);
        }
        internal static string CreateCompleteMessage(string message, params object[] parameters)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(message))
            {
                if (parameters == null)
                {
                    result = Assert.ReplaceNulls(message);
                }
                else
                {
                    result = string.Format(CultureInfo.CurrentCulture, Assert.ReplaceNulls(message), parameters);
                }
            }
            return result;
        }
        internal static void HandleFailure(string assertionName, string message)
        {
            //if (Assert.AssertionFailure != null)
            //{
            //    Assert.AssertionFailure(null, EventArgs.Empty);
            //}
            throw new AssertFailedException(assertionName + " " + message);
        }
        internal static void CheckParameterNotNull(object param, string assertionName, string parameterName, string message, params object[] parameters)
        {
            if (param == null)
            {
                Assert.HandleFail(assertionName, "NullParameterToAssert <" + parameterName + "> " + message, parameters);
            }
        }

        internal static string ReplaceNulls(object input)
        {
            if (input == null)
            {
                return "Common_NullInMessages";
            }
            string text = input.ToString();
            if (text == null)
            {
                return "Common_ObjectString";
            }
            return Assert.ReplaceNullChars(text);
        }

        public static string ReplaceNullChars(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            List<int> list = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\0')
                {
                    list.Add(i);
                }
            }
            if (list.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder(input.Length + list.Count);
                int num = 0;
                foreach (int current in list)
                {
                    stringBuilder.Append(input.Substring(num, current - num));
                    stringBuilder.Append("\\0");
                    num = current + 1;
                }
                stringBuilder.Append(input.Substring(num));
                return stringBuilder.ToString();
            }
            return input;
        }
    }
}
