using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexCell : MonoBehaviour
{
    private Mesh mesh;

    [SerializeField]
    private MeshCollider meshCollider;

    public HexCellData Data { get; private set; }

    public HexCoordinate Pos
    {
        get
        {
            return Data.Pos;
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
        Data = _data;
    }
}