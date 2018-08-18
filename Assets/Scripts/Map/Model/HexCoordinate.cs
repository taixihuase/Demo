using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct HexCoordinate
{
    public int Row { get; private set; }

    public int Column { get; private set; }

    public void SetPos(int _row, int _col)
    {
        Row = _row;
        Column = _col;
    }

    public HexCoordinate(int _row, int _col)
    {
        Row = _row;
        Column = _col;
    }

    public override string ToString()
    {
        return StringTool.Str_Left_Bracket + Row.ToString() + StringTool.Str_Comma + Column.ToString() + StringTool.Str_Right_Bracket;
    }
}
