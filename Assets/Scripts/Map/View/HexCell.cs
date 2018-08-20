using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexCell : MonoBehaviour
{
    private Mesh mesh;

    [SerializeField]
    private MeshCollider meshCollider;

    [SerializeField]
    private HexCellData data;

    public HexCellData Data
    {
        get
        {
            return data;
        }
    }

    public HexCoordinate Pos
    {
        get
        {
            return Data.Pos;
        }
    }

    private HexCell[] neighbor;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "HexCell";
        mesh.vertices = HexConst.vertices;
        mesh.triangles = HexConst.triangles;
        mesh.colors = HexConst.colors;
        meshCollider.sharedMesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial.color = HexConst.defaultColor;
    }

    public void SetData(HexCellData _data)
    {
        data = _data;
        neighbor = new HexCell[6];
    }

    public void SetNeighbor(MapDirectionType dir, HexCell cell)
    {
        neighbor[(int)dir] = cell;
    }
}