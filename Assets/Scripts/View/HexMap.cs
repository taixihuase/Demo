using System.Collections.Generic;
using UnityEngine;
public class HexMap
{
    public HexCell[][] cells;

    public HexMap(int[] cols)
    {
        cells = new HexCell[cols.Length][];
        for(int i = 0; i < cols.Length; i++)
        {
            cells[i] = new HexCell[cols[i]];
        }
    }

    public HexMap(List<int> cols)
    {
        cells = new HexCell[cols.Count][];
        for (int i = 0; i < cols.Count; i++)
        {
            cells[i] = new HexCell[cols[i]];
        }
    }

    public void SetCell(HexCell cell, int row, int col)
    {
        cells[row][col] = cell;
    }
}