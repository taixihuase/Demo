using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HexCellData
{
    private HexCoordinate pos;
    public HexCoordinate Pos
    {
        get
        {
            return pos;
        }
    }

    public void SetPos(HexCoordinate _pos)
    {
        pos = _pos;
    }
}
