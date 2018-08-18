using System;
using UnityEngine;

[Serializable]
public class HexCellData
{
    [SerializeField]
    private HexCoordinate pos;

    public HexCoordinate Pos
    {
        get
        {
            return pos;
        }
    }

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
        pos = _pos;
    }
}
