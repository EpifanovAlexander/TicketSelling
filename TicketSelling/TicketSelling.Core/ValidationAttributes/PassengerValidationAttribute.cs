using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
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
                result &= CheckRuleForPassenger(IsTicketNumberValid, passenger, "Предъявлен билет с невалидным номером");
                result &= CheckRuleForPassenger(IsRequiredPropertiesNotNull, passenger);
                return result;
            }
            return false;
        }

        private bool CheckRuleForPassenger(IsPropertyValidDelegate validMethod, PassengerDto passenger)
        {
            return validMethod.Invoke(passenger);
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
        private bool IsTicketNumberValid(PassengerDto passenger)
        {
            Regex regex = new Regex(@"^(\d{13})$");
            return regex.IsMatch(passenger.TicketNumber);
        }

        private bool IsRequiredPropertiesNotNull(PassengerDto passenger)
        {
            var result = true;
            result &= CheckRequiredProperty(passenger.Name, "Имя пассажира не может быть пустым");
            result &= CheckRequiredProperty(passenger.Surname, "Фамилия пассажира не может быть пустой");
            result &= CheckRequiredProperty(passenger.DocumentType, "Тип документа должен быть определён");
            result &= CheckRequiredProperty(passenger.DocumentNumber, "Номер документа должен быть определён");
            result &= CheckRequiredProperty(passenger.Birthdate, "Дата рождения пассажира не может быть пустой");
            result &= CheckRequiredProperty(passenger.TicketNumber, "Номер билета должен быть определён");
            result &= CheckRequiredProperty(passenger.TicketType, "Тип билета должен быть определён");
            return result;
        }

        private bool CheckRequiredProperty<T>(T property, string message)
        {
            if (property is null)
            {
                ErrorMessage += message + ". ";
                return false;
            }
            return true;
        }
    }
}
