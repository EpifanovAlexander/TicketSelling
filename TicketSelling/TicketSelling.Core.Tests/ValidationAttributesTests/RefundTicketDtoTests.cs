using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSelling.Core.Domains.Tickets.Dto;
using Xunit;

namespace TicketSelling.Core.Tests.ValidationAttributesTests
{
    public class RefundTicketDtoTests
    {
        [Fact]
        public void TicketWithIncorrectOperation_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var ticketWithIncorrectOperation = new RefundTicketDto(null, DateTimeOffset.Now, "Aeroport", "5552139265672");
            var context = new ValidationContext(ticketWithIncorrectOperation);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithIncorrectOperation, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void TicketWithoutNumber_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var ticketWithoutNumber = new RefundTicketDto("refund", DateTimeOffset.Now, "Aeroport", null);
            var context = new ValidationContext(ticketWithoutNumber);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithoutNumber, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void TicketWithTooLongNumber_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var ticketWithTooLongNumber = new RefundTicketDto("refund", DateTimeOffset.Now, "Aeroport", "too_long_ticket_number");
            var context = new ValidationContext(ticketWithTooLongNumber);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithTooLongNumber, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void TicketWithTooSmallNumber_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var ticketWithTooSmallNumber = new RefundTicketDto("refund", DateTimeOffset.Now, "Aeroport", "2");
            var context = new ValidationContext(ticketWithTooSmallNumber);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithTooSmallNumber, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void TicketWithCorrectLengthNumber_AndContainsLetters_ReturnFalse()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var ticketWithLetters = new RefundTicketDto("refund", DateTimeOffset.Now, "Aeroport", "5552139W65672");
            var context = new ValidationContext(ticketWithLetters);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithLetters, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void CorrectTicket_ReturnTrue()
        {
            // ARRANGE
            var results = new List<ValidationResult>();
            var ticketWithLetters = new RefundTicketDto("refund", DateTimeOffset.Now, "Aeroport", "5552139765672");
            var context = new ValidationContext(ticketWithLetters);

            // ACT
            var validateResult = Validator.TryValidateObject(ticketWithLetters, context, results, true);

            // ASSERT
            Assert.True(validateResult);
        }
    }
}
