using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSelling.Core.Domains.Segments.Dto;
using Xunit;

namespace TicketSelling.Core.Tests.ValidationAttributesTests
{
    public class SegmentDtoTests
    {
        [Fact]
        public void SegmentWithoutAirlineCode_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var segmentWithoutAirlineCode = new SegmentDto(null, 1, "departPlace", DateTimeOffset.Now, "arrivePlace", DateTimeOffset.Now, "pnrId");
            var context = new ValidationContext(segmentWithoutAirlineCode);

            // ACT
            var validateResult = Validator.TryValidateObject(segmentWithoutAirlineCode, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void SegmentWithoutDepartPlace_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var segmentWithoutDepartPlace = new SegmentDto("airlineCode", 1, null, DateTimeOffset.Now, "arrivePlace", DateTimeOffset.Now, "pnrId");
            var context = new ValidationContext(segmentWithoutDepartPlace);

            // ACT
            var validateResult = Validator.TryValidateObject(segmentWithoutDepartPlace, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void SegmentWithoutArrivePlace_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var segmentWithoutArrivePlace = new SegmentDto("airlineCode", 1, "departPlace", DateTimeOffset.Now, null, DateTimeOffset.Now, "pnrId");
            var context = new ValidationContext(segmentWithoutArrivePlace);

            // ACT
            var validateResult = Validator.TryValidateObject(segmentWithoutArrivePlace, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void SegmentWithoutPnrId_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var segmentWithoutPnrId = new SegmentDto("airlineCode", 1, "departPlace", DateTimeOffset.Now, "arrivePlace", DateTimeOffset.Now, null);
            var context = new ValidationContext(segmentWithoutPnrId);

            // ACT
            var validateResult = Validator.TryValidateObject(segmentWithoutPnrId, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void CorrectSegment_ReturnTrue()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var correctSegment = new SegmentDto("airlineCode", 1, "departPlace", DateTimeOffset.Now, "arrivePlace", DateTimeOffset.Now, "pnrId");
            var context = new ValidationContext(correctSegment);

            // ACT
            var validateResult = Validator.TryValidateObject(correctSegment, context, results, true);

            // ASSERT
            Assert.True(validateResult);
        }
    }
}
