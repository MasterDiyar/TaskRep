using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using fptest.weapon.json;
using Godot;
using FileAccess = Godot.FileAccess;

namespace fptest.weapon;

public class WeaponLoader
{
    //Eto JSONLOADER <-------- ETO JSONLOADET DALBAEB
    public static async Task<T> LoadAsync<T>(string path)
    {
        if (!FileAccess.FileExists(path))
        {
            GD.PrintErr($"[JsonLoader] File not found: {path}");
            return default;
        }

        using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
        var json = file.GetAsText();

        if (string.IsNullOrEmpty(json))
        {
            GD.PrintErr($"[JsonLoader] File is empty: {path}");
            return default;
        }

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            // асинхронная десериализация из строки (а не из потока)
            using var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            return await JsonSerializer.DeserializeAsync<T>(ms, options);
        }
        catch (Exception e)
        {
            GD.PrintErr($"[JsonLoader] Failed to parse {path}: {e.Message}");
            return default;
        }
    }

    public static async Task<Dictionary<TKey, TValue>> LoadDictionaryAsync<TKey, TValue>(string path)
    {
        if (!FileAccess.FileExists(path))
        {
            GD.PrintErr($"[JsonLoader] Dictionary file not found: {path}");
            return default;
        }

        using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
        var json = file.GetAsText();

        using var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));

        try
        {
            return await JsonSerializer.DeserializeAsync<Dictionary<TKey, TValue>>(ms);
        }
        catch (Exception e)
        {
            GD.PrintErr($"[JsonLoader] Failed to parse dictionary {path}: {e.Message}");
            return default;
        }
    }
}