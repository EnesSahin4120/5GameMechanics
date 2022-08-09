using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Wall : MonoBehaviour
{
    private int _wallSize = 30;
    private int _frameCount = 30;

    private List<Vector3> _vertices = new List<Vector3>();
    public List<Vector3> Vertices
    {
        get
        {
            return _vertices;
        }
        set
        {
            _vertices = value;
        }
    }
    private List<Vector3> _normals = new List<Vector3>();
    private List<int> _triangles = new List<int>();
    private List<Vector2> _uvs = new List<Vector2>();

    private MeshFilter _meshFilter;
    private MeshCollider _meshColl;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshColl = GetComponent<MeshCollider>();
    }

    private void Start()
    {
        CreateWall();
        UpdateMesh();
    }

    private void CreateWall()
    {
        float frame = _wallSize / _frameCount;
        for (int i = 0; i < _frameCount + 1; i++)
        {
            for (int j = 0; j < _frameCount + 1; j++)
            {
                _vertices.Add(new Vector3(j * frame, i * frame, 0));
                _normals.Add(Vector3.back);
                _uvs.Add(new Vector2(i / (float)_frameCount, j / (float)_frameCount));
            }
        }


        for (int i = 0; i < _frameCount; i++)
        {
            for (int j = 0; j < _frameCount; j++)
            {
                int currentIndex = (i * _frameCount) + i + j;

                //Triangle 1
                _triangles.Add(currentIndex);
                _triangles.Add(currentIndex + _frameCount + 1);
                _triangles.Add(currentIndex + _frameCount + 2);

                //Triangle 2
                _triangles.Add(currentIndex);
                _triangles.Add(currentIndex + _frameCount + 2);
                _triangles.Add(currentIndex + 1);
            }
        }
    }

    public void UpdateMesh()
    {
        _meshFilter.mesh.SetVertices(_vertices);
        _meshFilter.mesh.SetTriangles(_triangles, 0);
        _meshFilter.mesh.SetNormals(_normals);
        _meshFilter.mesh.SetUVs(0, _uvs);
        _meshColl.sharedMesh = _meshFilter.mesh;
    }
}
