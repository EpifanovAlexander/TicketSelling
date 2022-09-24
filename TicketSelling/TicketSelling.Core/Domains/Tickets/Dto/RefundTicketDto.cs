﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketSelling.Core.Domains.Tickets.Dto
{
    public class RefundTicketDto
    {
        [Required(ErrorMessage = "Тип операции должен быть определён")]
        [JsonPropertyName("operation_type")]
        public string OperationType { get; set; }

        [JsonPropertyName("operation_time")]
        public DateTimeOffset OperationTime { get; set; }

        [JsonPropertyName("operation_place")]
        public string OperationPlace { get; set; }

        [Required(ErrorMessage = "Номер билета должен быть определён")]
        [RegularExpression(@"^(\d{13})$", ErrorMessage = "Невалидный номер билета")]
        [JsonPropertyName("ticket_number")]
        public string TicketNumber { get; set; }

        public RefundTicketDto(string operationType, DateTimeOffset operationTime, string operationPlace, string ticketNumber)
        {
            OperationType = operationType;
            OperationTime = operationTime;
            OperationPlace = operationPlace;
            TicketNumber = ticketNumber;
        }
    }
}
