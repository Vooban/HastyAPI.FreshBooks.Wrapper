﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace Vooban.FreshBooks.Tests
{
    public class FreshbooksConvertTests
    {
        public class FromBoolean
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.FromBoolean(null));
            }

            [Fact]
            public void ValueReturnsTrueAsExpected()
            {
                Assert.Equal("1", FreshbooksConvert.FromBoolean(true));
            }

            [Fact]
            public void ValueReturnsFalseAsExpected()
            {
                Assert.Equal("0", FreshbooksConvert.FromBoolean(false));
            }
        }

        public class FromDouble
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.FromDouble(null));
            }

            [Fact]
            public void ValueWithoutFractionReturnsAsExpected()
            {
                Assert.Equal("34", FreshbooksConvert.FromDouble(34));
            }

            [Fact]
            public void ValueWithFractionReturnsAsExpected()
            {
                Assert.Equal("34.48", FreshbooksConvert.FromDouble(34.48));
            }
        }

        public class FromPercentage
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.FromPercentage(null));
            }

            [Fact]
            public void PercentageReturnsAsExpected()
            {
                Assert.Equal("34", FreshbooksConvert.FromPercentage(0.34));
            }

            [Fact]
            public void PercentageUnderZeroThrowsAsExpected()
            {
                Assert.Throws<ArgumentException>(() => FreshbooksConvert.FromPercentage(-1));
            }

            [Fact]
            public void PercentageAboveOneThrowsAsExpected()
            {
                Assert.Throws<ArgumentException>(() => FreshbooksConvert.FromPercentage(1.1));
            }
        }

        public class FromInteger
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.FromInteger(null));
            }

            [Fact]
            public void ValueReturnsAsExpected()
            {
                Assert.Equal("34", FreshbooksConvert.FromInteger(34));
            } 
        }

        public class FromDateTime
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.FromDateTime(null));
            }

            [Fact]
            public void ValueReturnsAsExpected()
            {
                Assert.Equal("2000-01-01 10:10:10", FreshbooksConvert.FromDateTime(new DateTime(2000, 01, 01, 10, 10, 10)));
            } 
        }

        public class ToBoolean
        {
             [Fact]
             public void NullValueReturnsFalse()
             {
                 Assert.False(FreshbooksConvert.ToBoolean(null));
             }

             [Fact]
             public void EmptyValueReturnsFalse()
             {
                 Assert.False(FreshbooksConvert.ToBoolean(""));
             }

             [Fact]
             public void WhitespacesValueReturnsFalse()
             {
                 Assert.False(FreshbooksConvert.ToBoolean("  "));
             }

             [Fact]
             public void ZeroValueReturnsFalse()
             {
                 Assert.False(FreshbooksConvert.ToBoolean("0"));
             }

             [Fact]
             public void OneValueReturnsTrue()
             {
                 Assert.True(FreshbooksConvert.ToBoolean("1"));
             }

             [Fact]
             public void WeirdValueReturnsFalse()
             {
                 Assert.False(FreshbooksConvert.ToBoolean("5"));
             }
        }

        public class ToDouble
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToDouble(null));
            }

            [Fact]
            public void EmptyValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToDouble(""));
            }

            [Fact]
            public void WhitespaceValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToDouble("  "));
            }

            [Fact]
            public void DoubleValueWithoutFractionReturnsRightValue()
            {
                Assert.Equal(3d, FreshbooksConvert.ToDouble("3"));
            }

            [Fact]
            public void DoubleValueWithFractionReturnsRightValue()
            {
                Assert.Equal(3.4d, FreshbooksConvert.ToDouble("3.4"));
            }           
        }

        public class ToInteger
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToInt32((string)null));
            }

            [Fact]
            public void ObjectNullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToInt32((object)null));
            }            

            [Fact]
            public void EmptyValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToInt32(""));
            }

            [Fact]
            public void WhitespaceValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToInt32("  "));
            }

            [Fact]
            public void ValueReturnsRightValue()
            {
                Assert.Equal(3, FreshbooksConvert.ToInt32("3"));
            }

            [Fact]
            public void ObjectEmptyValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToInt32((object)""));
            }

            [Fact]
            public void ObjectWhitespaceValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToInt32((object)"  "));
            }

            [Fact]
            public void ObjectValueReturnsRightValue()
            {
                Assert.Equal(3, FreshbooksConvert.ToInt32((object)"3"));
            }
        }

        public class ToPercentage
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToPercentage(null));
            }

            [Fact]
            public void EmptyValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToPercentage(""));
            }

            [Fact]
            public void WhitespaceValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToPercentage("  "));
            }

            [Fact]
            public void DoubleValueWithoutFractionReturnsRightValue()
            {
                Assert.Equal(0.03d, FreshbooksConvert.ToPercentage("3"));
            }

            [Fact]
            public void DoubleValueWithFractionReturnsRightValue()
            {
                Assert.Equal(0.034d, FreshbooksConvert.ToPercentage("3.4"));
            }
        }

        public class ToDateTime
        {
            [Fact]
            public void NullValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToDateTime(null));
            }

            [Fact]
            public void EmptyValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToDateTime(""));
            }

            [Fact]
            public void WhitespaceValueReturnsNull()
            {
                Assert.Null(FreshbooksConvert.ToDateTime("  "));
            }

            [Fact]
            public void ValueParseExactlyAsExpected()
            {
                Assert.Equal(new DateTime(2013,10,15,14,03,25), FreshbooksConvert.ToDateTime("2013-10-15 14:03:25"));
            }

        }
    
        public class ToResponse
        {
            [Fact]
            public void NullDynamicValueReturnsNull()
            {
                Assert.Throws<ArgumentNullException>(()=> FreshbooksConvert.ToGetResponse<String>(null));                
            }

            [Fact]
            public void InvalidDynamicValueFailsWithProperException()
            {
                dynamic value = JsonConvert.DeserializeObject("{ response : { status : \"ok\"} }");

                var result = FreshbooksConvert.ToGetResponse<String>(value);
                
                Assert.True(result.Success);                
            }
        }
    }
}
