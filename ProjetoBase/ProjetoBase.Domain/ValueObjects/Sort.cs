using System.ComponentModel;
using ProjetoBase.Domain.Shared;

namespace ProjetoBase.Domain.ValueObjects
{
    public class Sort : ValueObject<Sort>
    {
        public enum Direction
        {
            [Description("asc")] Asc,

            [Description("desc")] Desc
        }

        public Direction Dir { get; }

        public Sort(string direction)
        {
            Dir = !string.IsNullOrEmpty(direction) ? EnumExtensions.GetEnumValueFromDescription<Direction>(direction) : Direction.Asc;
        }

        public override string ToString()
        {
            return Dir.GetEnumDescription();
        }

        public static implicit operator string(Sort sort)
        {
            return sort.Dir.GetEnumDescription();
        }

        public static implicit operator Direction(Sort sort)
        {
            return sort.Dir;
        }

        public static implicit operator Sort(string direction)
        {
            return new Sort(direction);
        }

        protected override bool EqualsCore(Sort other)
        {
            return other.Dir == Dir;
        }

        protected override int GetHashCodeCore()
        {
            return Dir.GetHashCode();
        }
    }
}
