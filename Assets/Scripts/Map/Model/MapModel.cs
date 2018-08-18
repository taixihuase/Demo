using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MapModel : Notifier<MapModel>
{
    public HexCellData[,] mapData;

    public void InitMapData(int row, int col, List<HexCellData> datas)
    {
        mapData = new HexCellData[row, col];
        for (int i = 0; i < datas.Count; i++)
        {
            HexCellData dt = datas[i];
            mapData[dt.Row, dt.Column] = dt;
        }
        RaiseEvent(MapEventType.MAP_INIT);
    }
}
