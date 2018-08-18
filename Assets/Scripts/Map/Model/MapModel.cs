using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MapModel : Notifier<MapModel>
{
    public HexCellData[,] mapData;

    public void InitMapData(int row, int col)
    {
        mapData = new HexCellData[row, col];
    }

    public void SetCellData(HexCellData data)
    {
        mapData[data.Pos.Row, data.Pos.Column] = data;
    }
}
