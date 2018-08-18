using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HexCellData
{
    public HexCoordinate Pos { get; private set; }

    public int Row
    {
        get
        {
            return Pos.Row;
        }
    }

    public int Column
    {
        get
        {
            return Pos.Column;
        }
    }

    public void SetPos(HexCoordinate _pos)
    {
        Pos = _pos;
    }
}
