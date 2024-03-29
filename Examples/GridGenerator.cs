using UnityEngine;
using TOMICZ.Grid;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class GridGenerator : MonoBehaviour
{
    [SerializeField] private int gridWidth;

    [SerializeField] private int gridHeight;

    [SerializeField] private float spacing = .1f;
    
    [SerializeField] private float nodeWidth = 1f;

    [SerializeField] private float nodeHeight = 1f;

    private Mesh _mesh = null;

    private OptimizedGrid _grid;

    private void Awake()
    {
        _mesh = GetComponent<MeshFilter>().sharedMesh;
        _mesh.name = "Grid Mesh";

        Material gridMaterial = new Material(Shader.Find("Unlit/Color"));
        Renderer renderer = GetComponent<Renderer>();

        if(renderer != null)
        {
            renderer.material = gridMaterial;
        }
    }

    private void OnValidate()
    {
        _grid = new OptimizedGrid(gridWidth, gridHeight, nodeWidth, nodeHeight, spacing);

        _grid.GenerateGrid();
        _grid.LoadMeshData(_mesh);
    }
}
