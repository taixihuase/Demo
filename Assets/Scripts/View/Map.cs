using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private HexCell cellPrefab;

    private HexMap map;

    private void Awake()
    {
        int[] cols = new int[9] { 5, 4, 3, 2, 1, 2, 3, 4, 5 };
        map = new HexMap(cols);
        for(int i = 0; i < map.cells.Length; i++)
        {
            for(int j = 0; j < map.cells[i].Length; j++)
            {
                CreateCell(i, j);
            }
        }
    }

    void CreateCell(int row, int col)
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
        map.SetCell(cell, row, col);
    }
}
