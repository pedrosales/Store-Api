using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                    .Requires()
                    .IsEmail(address, "Email", "Email inválido")
            );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
