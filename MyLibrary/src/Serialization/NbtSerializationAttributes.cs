using MyLibrary.Core;

namespace MyLibrary.Serialization
{
    public enum MemberSerialization
    {
        OptIn,
        OptOut
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class NbtObjectAttribute : Attribute
    {
        public MemberSerialization MemberSerialization { get; }

        public NbtObjectAttribute(MemberSerialization memberSerialization)
        {
            MemberSerialization = memberSerialization;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NbtPropertyAttribute : Attribute
    {
    }

}