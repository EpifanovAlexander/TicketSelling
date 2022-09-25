using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSelling.Core.Domains.Passengers.Dto;
using TicketSelling.Core.Domains.Segments.Dto;
using TicketSelling.Core.Domains.Tickets.Dto;
using Xunit;

namespace TicketSelling.Core.Tests.ValidationAttributesTests
{
    public class SaleTicketDtoTests
    {
        [Fact]
        public void TicketWithIncorrectOperation_ReturnFalse()
        {
            // ARRANGE
            var correctPassenger = new PassengerDto("Name", "Surname", "Patronymic", "00", "1234567890", 
                DateTime.Parse("2001-07-12"), 'M', "type", "5552139265672", 1);
            var correctSegment = new SegmentDto("airlineCode", 1, "departPlace", DateTimeOffset.Now, "arrivePlace", DateTimeOffset.Now, "pnrId");
            var correctRoutes = new List<SegmentDto>() { correctSegment };

            var results = new List<ValidationResult>();
            var ticketWithIncorrectOperation = new SaleTicketDto(null, DateTimeOffset.Now, "Aeroport", correctPassenger, correctRoutes);
            var context = new ValidationContext(ticketWithIncorrectOperation);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithIncorrectOperation, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void TicketWithoutPassenger_ReturnFalse()
        {
            // ARRANGE
            var correctSegment = new SegmentDto("airlineCode", 1, "departPlace", DateTimeOffset.Now, "arrivePlace", DateTimeOffset.Now, "pnrId");
            var correctRoutes = new List<SegmentDto>() { correctSegment };

            var results = new List<ValidationResult>();
            var ticketWithoutPassenger = new SaleTicketDto("sale", DateTimeOffset.Now, "Aeroport", null, correctRoutes);
            var context = new ValidationContext(ticketWithoutPassenger);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithoutPassenger, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void TicketWithoutRoutes_ReturnFalse()
        {
            // ARRANGE
            var correctPassenger = new PassengerDto("Name", "Surname", "Patronymic", "00", "1234567890",
                    DateTime.Parse("2001-07-12"), 'M', "type", "5552139265672", 1);

            var results = new List<ValidationResult>();
            var ticketWithoutRoutes = new SaleTicketDto("sale", DateTimeOffset.Now, "Aeroport", correctPassenger, null);
            var context = new ValidationContext(ticketWithoutRoutes);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithoutRoutes, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void CorrectTicket_ReturnTrue()
        {
            // ARRANGE
            var correctPassenger = new PassengerDto("Name", "Surname", "Patronymic", "00", "1234567890",
                DateTime.Parse("2001-07-12"), 'M', "type", "5552139265672", 1);
            var correctSegment = new SegmentDto("airlineCode", 1, "departPlace", DateTimeOffset.Now, "arrivePlace", DateTimeOffset.Now, "pnrId");
            var correctRoutes = new List<SegmentDto>() { correctSegment };

            var results = new List<ValidationResult>();
            var ticketWithIncorrectOperation = new SaleTicketDto("sale", DateTimeOffset.Now, "Aeroport", correctPassenger, correctRoutes);
            var context = new ValidationContext(ticketWithIncorrectOperation);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithIncorrectOperation, context, results, true);

            // ASSERT
            Assert.True(validateResult);
        }
    }
}
