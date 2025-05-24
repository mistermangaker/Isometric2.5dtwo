using UnityEngine;
using UnityEngine.Tilemaps;

public class CliffsFaceTowardCamera : MonoBehaviour
{
    public Vector3 lookat;
    public Matrix4x4 lookie;
   public Tilemap Tilemap;
    public Quaternion rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Tilemap = GetComponent<Tilemap>();
        lookie = Tilemap.orientationMatrix;
    }
    private void OnValidate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        lookat = Tilemap.transform.position - Camera.main.transform.position;
         rotation = Quaternion.FromToRotation(transform.position,lookat);

        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(45f, rotation.y, 0f), Vector3.one);
        Tilemap.orientationMatrix = matrix;
     
    }

    private void OnDrawGizmos()
    {
        //lookie = Tilemap.orientationMatrix;
    }
}
