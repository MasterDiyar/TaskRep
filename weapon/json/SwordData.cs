using System;
using Godot;

namespace fptest.weapon.json;

[Serializable]
public class SwordData
{
    public string Name {get; set;}
    public float Durability {get; set;}
    public float Damage {get; set;}
    public float Stamina {get; set;}
    public string Path {get; set;}
}