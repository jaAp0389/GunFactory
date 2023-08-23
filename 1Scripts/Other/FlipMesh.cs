using UnityEngine;
using System.Linq;

/// <summary>
/// Class to flip normals on a mesh and turn it inside out.
/// Copied from Jessy on
/// https://answers.unity.com/questions/476810/flip-a-mesh-inside-out.html 
/// </summary>
public class FlipMesh : MonoBehaviour
{
    private void Awake()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}