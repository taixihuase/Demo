using System;
using UnityEngine;

[Serializable]
public struct HexCoordinate
{
    [SerializeField]
    private int row;
    public int Row
    {
        get
        {
            return row;
        }
    }

    [SerializeField]
    public int column;
    public int Column
    {
        get
        {
            return column;
        }
    }

    public void SetPos(int _row, int _col)
    {
        row = _row;
        column = _col;
    }

    public HexCoordinate(int _row, int _col)
    {
        row = _row;
        column = _col;
    }

    public override string ToString()
    {
        return StringTool.Str_Left_Bracket + Row.ToString() + StringTool.Str_Comma + Column.ToString() + StringTool.Str_Right_Bracket;
    }
}
