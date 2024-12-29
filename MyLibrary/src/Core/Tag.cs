using System.Collections;

namespace MyLibrary.Core;

public abstract class Tag {
    public string? Name { get; set; }
}

public class StringTag : Tag {
    public string Value { get; set; }

    public StringTag(string value) {
        Value = value;
    }

    public override string ToString() {
        return $"\"{Value}\"";
    }
}

public class DoubleTag : Tag {
    public double Value { get; set; }

    public DoubleTag(double value) {
        Value = value;
    }

    public override string ToString() {
        return $"{Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}D";
    }
}

public class ListTag<T> : Tag, IEnumerable<T> where T : Tag {
    public List<T> items = new List<T>();

    public void Add(T item) {
        items.Add(item);
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString() {
        return $"[{string.Join(", ", items)}]";
    }
}