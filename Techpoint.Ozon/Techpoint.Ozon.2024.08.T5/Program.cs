using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

/*
 * JSON prettify
 */
public class Program {
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        List<string> results = new List<string>();
        StringBuilder sb = new StringBuilder();
        JsonDocumentOptions documentOptions = new JsonDocumentOptions() {
            MaxDepth = int.MaxValue
        };
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions() {
            MaxDepth = int.MaxValue
        };
        byte t = byte.Parse(input.ReadLine());
        while (t > 0) {
            ushort n = ushort.Parse(input.ReadLine());
            while (n > 0) {
                sb.Append(input.ReadLine());
                n--;
            }
            using (JsonDocument document = JsonDocument.Parse(sb.ToString(), documentOptions)) {
                JsonElement root = document.RootElement;
                results.Add(JsonSerializer.Serialize(PrettifyRoot(root), serializerOptions));
            }
            sb.Clear();
            t--;
        }
        output.Write($"[{string.Join(',', results)}]");
    }

    private static object PrettifyRoot(JsonElement root) {
        if (root.ValueKind == JsonValueKind.Object) {
            return PrettifyObject(root);
        } else if (root.ValueKind == JsonValueKind.Array) {
            return PrettifyArray(root);
        } else {
            return GetValue(root);
        }
    }
    private static Dictionary<string, object> PrettifyObject(JsonElement element) {
        var dict = new Dictionary<string, object>();
        foreach (var property in element.EnumerateObject()) {
            var propertyValue = property.Value;
            if (propertyValue.ValueKind == JsonValueKind.Object) {
                var childDict = PrettifyObject(propertyValue);
                if (childDict.Count > 0) {
                    dict[property.Name] = childDict;
                }
            } else if (propertyValue.ValueKind == JsonValueKind.Array) {
                var childList = PrettifyArray(propertyValue);
                if (childList.Count > 0) {
                    dict[property.Name] = childList;
                }
            } else {
                var propValue = GetValue(propertyValue);
                if (propValue != null) {
                    dict[property.Name] = propValue;
                }
            }
        }
        return dict;
    }
    private static List<object> PrettifyArray(JsonElement element) {
        var arr = new List<object>();
        foreach (var arrayElement in element.EnumerateArray()) {
            if (arrayElement.ValueKind == JsonValueKind.Object) {
                var childDict = PrettifyObject(arrayElement);
                if (childDict.Count > 0) {
                    arr.Add(childDict);
                }
            } else if (arrayElement.ValueKind == JsonValueKind.Array) {
                var childList = PrettifyArray(arrayElement);
                if (childList.Count > 0) {
                    arr.Add(childList);
                }
            } else {
                var propValue = GetValue(arrayElement);
                if (propValue != null) {
                    arr.Add(propValue);
                }
            }
        }
        return arr;
    }
    private static object GetValue(JsonElement element) {
        switch (element.ValueKind) {
            case JsonValueKind.String: {
                return element.GetString();
            }
            case JsonValueKind.Number: {
                return element.GetDouble();
            }
            case JsonValueKind.True:
            case JsonValueKind.False: {
                return element.GetBoolean();
            }
            default: {
                return null;
            }
        }
    }
}