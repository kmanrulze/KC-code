using System;
using System.Collections.Generic;
using System.Text;
using Sequences.Library;
using Xunit;

namespace Sequence.Tests
{
    public class StringSequenceTests
    {
        [Fact] // this tells xUnit that this is test unit
        public void AddShouldAdd()
        {
            //arrange
            //any setup necessary to prepare for the behavior to test

            //act
            //do the thing you want to test

            //assert
            //verify behavior was as expected


            var seq = new StringSequences();

            seq.Add("abc");

            Assert.Equal(expected: "abc",actual: seq[0]);
            Assert.Equal(expected: "def", actual: seq[0]);
        }

        [Fact]
        public void AddShouldAddInConsistentOrder()
        {
            var seq = new StringSequences();

            Assert.ThrowsAny<ArgumentOutOfRangeException>(() =>
            {
                var x = seq[0];
            });
        }
    }
}
