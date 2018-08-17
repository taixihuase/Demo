using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexCell : MonoBehaviour
{
    private Mesh mesh;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "HexCell";
        mesh.vertices = HexConst.vertices;
        mesh.triangles = HexConst.triangles;
    }
}