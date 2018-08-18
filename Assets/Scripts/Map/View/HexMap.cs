using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    [SerializeField]
    private HexCell cellPrefab;

    private HexCell[,] cells;
    public HexCell[,] Cells
    {
        get
        {
            return cells;
        }
    }

    private int maxColumn;
    public int MaxColumn
    {
        get
        {
            return maxColumn;
        }
    }

    private int maxRow;
    public int MaxRow
    {
        get
        {
            return maxRow;
        }
    }

    private MapModel model;

    private void Awake()
    {
        model = MapModel.Inst;
        int[] cols = new int[9] { 5, 4, 3, 2, 1, 2, 3, 4, 5 };
        InitMap(cols);
        for(int i = 0; i < cols.Length; i++)
        {
            for(int j = 0; j < cols[i]; j++)
            {
                CreateCell(i, j);
            }
        }
    }

    public void InitMap(int[] cols)
    {
        maxRow = cols.Length;
        maxColumn = 0;
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i] > maxColumn)
            {
                maxColumn = cols[i];
            }
        }
        cells = new HexCell[cols.Length, maxColumn];
        model.InitMapData(maxRow, maxColumn);
    }

    public void InitMap(List<int> cols)
    {
        maxRow = cols.Count;
        maxColumn = 0;
        for (int i = 0; i < cols.Count; i++)
        {
            if (cols[i] > maxColumn)
            {
                maxColumn = cols[i];
            }
        }
        cells = new HexCell[cols.Count, maxColumn];
        model.InitMapData(maxRow, maxColumn);
    }

    private void CreateCell(int row, int col)
    {
        Vector3 position;
        if (row % 2 == 0)
        {
            position.x = HexConst.innerRadius + col * HexConst.innerRadius * 2f;
        }
        else
        {
            position.x = col * HexConst.innerRadius * 2f;
        }
        position.y = 0f;
        position.z = -row * HexConst.outerRadius * 1.5f;

        HexCell cell = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        HexCoordinate pos = new HexCoordinate(row, col);
        HexCellData data = new HexCellData();
        data.SetPos(pos);
        cell.SetData(data);
        cells[row, col] = cell;
        model.SetCellData(data);
    }
}
