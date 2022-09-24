using System.ComponentModel.DataAnnotations;
using TicketSelling.Core.Domains.Passengers.Dto;

namespace TicketSelling.Core.ValidationAttributes
{
    public class PassengerValidationAttribute: ValidationAttribute
    {
        private const int VALID_AGE = 14;

        private delegate bool IsPropertyValidDelegate(PassengerDto passenger);

        public override bool IsValid(object? value)
        {
            if (value is PassengerDto passenger)
            {
                var result = true;
                result &= CheckRuleForPassenger(IsAgeValid, passenger, $"Пассажир должен быть старше {VALID_AGE} лет");
                result &= CheckRuleForPassenger(IsGenderValid, passenger, $"Пассажир имеет некорректный пол");
                result &= CheckRuleForPassenger(IsDocumentValid, passenger, "Предъявлен невалидный документ");
                return result;
            }
            return false;
        }

        private bool CheckRuleForPassenger(IsPropertyValidDelegate validMethod, PassengerDto passenger, string message)
        {
            if (!validMethod.Invoke(passenger))
            {
                ErrorMessage += message + ". ";
                return false;
            }
            return true;
        }

        private bool IsAgeValid(PassengerDto passenger)
        {
            var birthDate = passenger.Birthdate;
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year - 1 +
                ((today.Month > birthDate.Month || today.Month == birthDate.Month && today.Day >= birthDate.Day) ? 1 : 0);
            return age >= VALID_AGE;
        }

        private bool IsGenderValid(PassengerDto passenger)
        {
            return passenger.Gender == 'M' || passenger.Gender == 'F';
        }

        private bool IsDocumentValid(PassengerDto passenger)
        {
            if (passenger.DocumentType == "00")
            {
                if (passenger.DocumentNumber.Length != 10)
                    return false;
                foreach (var item in passenger.DocumentNumber)
                {
                    if (!char.IsDigit(item))
                        return false;
                }
            }
            return true;
        }
    }
}
