using Godot;
using System;
using System.Collections.Generic;
using fptest.Items;

public partial class Inventory : Control
{
	public Dictionary<int, Item> Slots { get; private set; } = new();

	public void Swap(int from, int to)
	{
		if (!Slots.ContainsKey(from) && !Slots.ContainsKey(to)) return;

		(Slots[from], Slots[to]) = (Slots.ContainsKey(to) ? Slots[to] : null,
			Slots.ContainsKey(from) ? Slots[from] : null);
	}

	public void Set(int index, Item item)
	{
		Slots[index] = item;
	}

	public Item Get(int index)
	{
		return Slots.TryGetValue(index, out var item) ? item : null;
	}
}
