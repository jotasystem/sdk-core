namespace JotaSystem.Sdk.Core.Domain.ValueObjects
{
    public abstract class ValueObjectBase
    {
        public abstract override string ToString();
        public abstract IEnumerable<object?> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObjectBase)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode() =>
            GetEqualityComponents()
                .Aggregate(1, (hash, obj) => HashCode.Combine(hash, obj));

        public static bool operator ==(ValueObjectBase? a, ValueObjectBase? b) =>
            a is null && b is null || a is not null && a.Equals(b);

        public static bool operator !=(ValueObjectBase? a, ValueObjectBase? b) => !(a == b);
    }
}