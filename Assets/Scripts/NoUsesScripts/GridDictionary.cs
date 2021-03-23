using UnityEngine;
using System.Collections.Generic;

public class GridDictionary<TKey, TValue> : MonoBehaviour
{
    private Dictionary<TKey, TValue> grid;
    public TValue this[TKey x]
    {
        get => grid[x];
    }

    public void Add(TKey x, TValue y)
    {
        grid.Add(x, y);
    }

    public GridDictionary(int value)
    {
        grid = new Dictionary<TKey, TValue>(value);
    }
}
