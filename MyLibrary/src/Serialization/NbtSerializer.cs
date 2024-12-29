using System.Reflection;
using MyLibrary.Core;

namespace MyLibrary.Serialization
{


    public static class NbtSerializer
    {
        public static CompoundTag SerializeObject<T>(T obj)
        {
            var compoundTag = new CompoundTag();

            var type = typeof(T);

            var nbtObjectAttr = type.GetCustomAttribute<NbtObjectAttribute>();
            bool optIn = nbtObjectAttr?.MemberSerialization == MemberSerialization.OptIn;

            foreach (var property in type.GetProperties())
            {
                if (optIn && property.GetCustomAttribute<NbtPropertyAttribute>() == null)
                    continue;

                var value = property.GetValue(obj);
                if (value is string stringValue)
                    compoundTag[property.Name] = new StringTag(stringValue);
                else if (value is double doubleValue)
                    compoundTag[property.Name] = new DoubleTag(doubleValue);
                else if (value is IEnumerable<string> listValue)
                {
                    var listTag = new ListTag<StringTag>();
                    foreach (var item in listValue)
                    {
                        listTag.Add(new StringTag(item));
                    }
                    compoundTag[property.Name] = listTag;
                }
            }
            return compoundTag;
        }

        public static T DeserializeObject<T>(CompoundTag compoundTag) where T : new()
        {
            var obj = new T();
            var type = typeof(T);

            var nbtObjectAttr = type.GetCustomAttribute<NbtObjectAttribute>();
            bool optIn = nbtObjectAttr?.MemberSerialization == MemberSerialization.OptIn;

            foreach (var property in type.GetProperties())
            {
                if (optIn && property.GetCustomAttribute<NbtPropertyAttribute>() == null)
                    continue;

                if (compoundTag.tags.TryGetValue(property.Name, out var value))
                {
                    if (value is StringTag stringTag)
                        property.SetValue(obj, stringTag.Value);
                    else if (value is DoubleTag doubleTag)
                        property.SetValue(obj, doubleTag.Value);
                    else if (value is ListTag<StringTag> listTag)
                    {
                        var list = listTag.Select(tag => tag.Value).ToList();
                        property.SetValue(obj, list);
                    }
                }
            }
            return obj;
        }
    }
}
