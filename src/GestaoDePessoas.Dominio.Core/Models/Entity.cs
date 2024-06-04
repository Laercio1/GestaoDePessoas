namespace GestaoDePessoas.Dominio.Core.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            ID = Guid.NewGuid();
        }

        public virtual Guid ID { get; set; }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + ID.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[ID = " + ID + "]";
        }
    }
}
