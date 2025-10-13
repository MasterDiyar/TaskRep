using System;
using Godot;

namespace fptest.weapon.json;

public class SwordData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Durability { get; set; }
    public int Damage { get; set; }
    public float Stamina { get; set; }
    public float AttackSpeed { get; set; }
    public int Range { get; set; }
    public int Crit { get; set; }
    public int Pierce { get; set; }
    public string Path { get; set; }
}