using EjemploApiRest.Abstractions;

namespace EjemploApiRest.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
