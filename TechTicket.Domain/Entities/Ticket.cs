using System.ComponentModel.DataAnnotations;

namespace TechTicket.Domain.Entities
{
    public class Ticket
    {
        public Ticket(Guid id, string title, string requestingStore, string emailStore, string phoneStore, string description, DateTime createdAt)
        {
            Id = id;
            Title = title;
            RequestingStore = requestingStore;
            EmailStore = emailStore;
            PhoneStore = phoneStore;
            Description = description;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o assunto do chamado")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a filial")]
        [StringLength(80)]
        public string RequestingStore { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o email da filial")]
        [StringLength(100)]

        public string EmailStore { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o telefone da filial")]
        public string PhoneStore { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descreva o assunto do chamado")]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
