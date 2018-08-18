using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    [SerializeField]
    private HexCell cellPrefab;

    public HexCell[,] Cells { get; private set; }

    public int MaxColumn { get; private set; }

    public int MaxRow { get; private set; }

    private MapModel model;

    private void Awake()
    {
        model = MapModel.Inst;
        int[] cols = new int[9] { 5, 4, 3, 2, 1, 2, 3, 4, 5 };
        InitMap(cols);        
    }

    public void InitMap(int[] cols)
    {
        MaxRow = cols.Length;
        MaxColumn = 0;
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i] > MaxColumn)
            {
                MaxColumn = cols[i];
            }
        }
        Cells = new HexCell[cols.Length, MaxColumn];
        List<HexCellData> dataList = new List<HexCellData>();
        for (int i = 0; i < cols.Length; i++)
        {
            for (int j = 0; j < cols[i]; j++)
            {
                dataList.Add(CreateCell(i, j));
            }
        }
        model.InitMapData(MaxRow, MaxColumn, dataList);
    }

    public void InitMap(List<int> cols)
    {
        MaxRow = cols.Count;
        MaxColumn = 0;
        for (int i = 0; i < cols.Count; i++)
        {
            if (cols[i] > MaxColumn)
            {
                MaxColumn = cols[i];
            }
        }
        Cells = new HexCell[cols.Count, MaxColumn];
        List<HexCellData> dataList = new List<HexCellData>();
        for (int i = 0; i < cols.Count; i++)
        {
            for (int j = 0; j < cols[i]; j++)
            {
                dataList.Add(CreateCell(i, j));
            }
        }
        model.InitMapData(MaxRow, MaxColumn, dataList);
    }

    private HexCellData CreateCell(int row, int col)
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
        Cells[row, col] = cell;
        return data;
    }
}
