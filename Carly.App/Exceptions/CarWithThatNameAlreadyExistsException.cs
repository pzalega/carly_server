using Carly.Shared.Exceptions;

namespace Carly.App.Exceptions
{
    internal class CarWithThatNameAlreadyExistsException : DomainException
    {
        public string Name { get; set; }

        public CarWithThatNameAlreadyExistsException(string name) : base($"Car with name '{name}' already exists")
        {
            Name = name;
        }
    }
}
