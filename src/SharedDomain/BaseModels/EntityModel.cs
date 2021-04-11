using System;

namespace SharedDomain.BaseModels
{
    public abstract class EntityModel
    {
        protected EntityModel()
        { }

        ///TODO: Entender como sobreescrever esse construtor em projetos que os herdam...
        ///Ao utilizar ORM:
        /// -> utilizar banco MariaDb, eu preciso criar valor para o Id antes do SaveChanges;
        /// -> Ao utilizar SqlServer, se eu fizer isso, causo uma exceção;
        ///Id = Guid.NewGuid();
        public Guid Id { get; protected set; }
    }
}