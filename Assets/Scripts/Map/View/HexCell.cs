using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexCell : MonoBehaviour
{
    private Mesh mesh;

    [SerializeField]
    private MeshCollider meshCollider;

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
            return data.Pos;
        }
    }

    void Start()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "HexCell";
        mesh.vertices = HexConst.vertices;
        mesh.triangles = HexConst.triangles;
        //mesh.colors = HexConst.colors;
        meshCollider.sharedMesh = mesh;
    }

    public void SetData(HexCellData _data)
    {
        data = _data;
    }
}