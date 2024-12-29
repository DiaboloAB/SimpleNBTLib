namespace MyLibrary.Core;

public class CompoundTag : Tag {
    public Dictionary<String, Tag> tags = new Dictionary<string, Tag>();

    public Tag this[string tag] {
        get { return tags[tag]; }
        set { tags[tag] = value;}
    }

    public override string ToString() {
        var entries = tags.Select(kvp => $"{kvp.Key}: {kvp.Value}");
        return $"{{{string.Join(", ", entries)}}}";
    }
}

