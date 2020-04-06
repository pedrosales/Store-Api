using FluentValidator;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.CustomerCommands.Outputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se cpf já existe na base
            if(_customerRepository.CheckDocument(command.Document))
                AddNotification("Document", "Este cpf já está em uso.");

            // Verificar se o email já existe na base
            if(_customerRepository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já está em uso");

            // Criar as VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validade entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email);
            AddNotifications(customer.Notifications);

            if(Invalid)
                return null;

            // Persistir o cliente
            _customerRepository.Save(customer);

            // Enviar um email de boas vindas
            _emailService.Send(email.Address, "pedroivossantos@gmail.com", "Bem vindo", "Seja bem vindo ao Store");

            // Retornar o resultado para tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}