using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSelling.Core.Domains.Passengers.Dto;
using Xunit;

namespace TicketSelling.Core.Tests.ValidationAttributesTests
{
    public class PassengerDtoTests
    {
        [Fact]
        public void PassengerWithoutName_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var passengerWithoutName = new PassengerDto(null, "Surname", "Patronymic", "00", "1234567890",
               DateTime.Parse("2001-07-12"), 'M', "type", "5552139265672", 1);
            var context = new ValidationContext(passengerWithoutName);
            // ACT
            var validateResult = Validator.TryValidateObject(passengerWithoutName, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void PassengerWithoutSurname_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var passengerWithoutSurname = new PassengerDto("Name", null, "Patronymic", "00", "1234567890",
               DateTime.Parse("2001-07-12"), 'M', "type", "5552139265672", 1);
            var context = new ValidationContext(passengerWithoutSurname);
            // ACT
            var validateResult = Validator.TryValidateObject(passengerWithoutSurname, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void PassengerWithoutDocumentType_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var passengerWithoutDocumentType = new PassengerDto("Name", "Surname", "Patronymic", null, "1234567890",
               DateTime.Parse("2001-07-12"), 'M', "type", "5552139265672", 1);
            var context = new ValidationContext(passengerWithoutDocumentType);
            // ACT
            var validateResult = Validator.TryValidateObject(passengerWithoutDocumentType, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void PassengerWithoutDocumentNumber_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var passengerWithoutDocumentNumber = new PassengerDto("Name", "Surname", "Patronymic", "00", null,
               DateTime.Parse("2001-07-12"), 'M', "type", "5552139265672", 1);
            var context = new ValidationContext(passengerWithoutDocumentNumber);
            // ACT
            var validateResult = Validator.TryValidateObject(passengerWithoutDocumentNumber, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void PassengerWithoutTicketNumber_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var passengerWithoutTicketNumber = new PassengerDto("Name", "Surname", "Patronymic", "00", "1234567890",
               DateTime.Parse("2001-07-12"), 'M', "type", null, 1);
            var context = new ValidationContext(passengerWithoutTicketNumber);
            // ACT
            var validateResult = Validator.TryValidateObject(passengerWithoutTicketNumber, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void UnderagePassenger_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var underagePassenger = new PassengerDto("Name", "Surname", "Patronymic", "00", "1234567890",
               DateTime.Parse("2021-07-12"), 'M', "type", "5552139265672", 1);
            var context = new ValidationContext(underagePassenger);
            // ACT
            var validateResult = Validator.TryValidateObject(underagePassenger, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void PassengerWithIncorrectGender_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var passengerWithIncorrectGender = new PassengerDto("Name", "Surname", "Patronymic", "00", "1234567890",
               DateTime.Parse("2021-07-12"), 'S', "type", "5552139265672", 1);
            var context = new ValidationContext(passengerWithIncorrectGender);
            // ACT
            var validateResult = Validator.TryValidateObject(passengerWithIncorrectGender, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void PassengerWithDocType00_AndIncorrectDocNumberLength_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var passengerWithIncorrectDocNumberLength = new PassengerDto("Name", "Surname", "Patronymic", "00", "1111",
               DateTime.Parse("2021-07-12"), 'M', "type", "5552139265672", 1);
            var context = new ValidationContext(passengerWithIncorrectDocNumberLength);
            // ACT
            var validateResult = Validator.TryValidateObject(passengerWithIncorrectDocNumberLength, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void PassengerWithDocType00_AndDocNumberContainsLetters_ReturnFalse()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var passengerWithIncorrectDocNumberLength = new PassengerDto("Name", "Surname", "Patronymic", "00", "123456789V",
               DateTime.Parse("2021-07-12"), 'M', "type", "5552139265672", 1);
            var context = new ValidationContext(passengerWithIncorrectDocNumberLength);
            // ACT
            var validateResult = Validator.TryValidateObject(passengerWithIncorrectDocNumberLength, context, results, true);

            // ASSERT
            Assert.False(validateResult);
        }

        [Fact]
        public void CorrectPassenger_ReturnTrue()
        {
            // ARRANGE        
            var results = new List<ValidationResult>();
            var correctPassenger = new PassengerDto("Name", "Surname", "Patronymic", "00", "1234567890",
               DateTime.Parse("2001-07-12"), 'M', "type", "5552139265672", 1);
            var context = new ValidationContext(correctPassenger);
            // ACT
            var validateResult = Validator.TryValidateObject(correctPassenger, context, results, true);

            // ASSERT
            Assert.True(validateResult);
        }

    }
}
