using System;
using dups;
using Xunit;

namespace dups.test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("abcde", 0)]
        [InlineData("aabbcde", 2)]
        [InlineData("aabBcde", 2)]
        [InlineData("indivisibility", 1)]
        [InlineData("Indivisibilities", 2)]
        [InlineData("aA11", 2)]
        [InlineData("ABBA", 2)]
        public void AlphaNumChars(string test, int expected)
        {
            int target = dups.Util.FindDups(test);   
            Assert.Equal(target, expected);
        }
        [Theory]
        [InlineData("a##%cde")]
        [InlineData("abc)e")]
        [InlineData("abcd^")]
        public void NonAlphaNumChars(string test)
        {
            int target = dups.Util.FindDups(test);
            Assert.Equal(target, -1);
        }
    }
}
