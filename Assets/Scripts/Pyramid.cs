using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pyramid : MonoBehaviour
{
    [SerializeField] float increment;
    
    Mesh mesh;
    Vector3[] verts;
    int[] faces;
    Vector3[] modified;

    float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
       mesh = new Mesh();
       GetComponent<MeshFilter>().mesh = mesh;

       // The vertices
       verts = new Vector3[4];
       verts[0] = new Vector3(4.562f,-4.824f,5.266f);
       verts[1] = new Vector3(1.062f,-4.824f,5.266f);
       verts[2] = new Vector3(2.812f,-4.824f,8.298f);
       verts[3] = new Vector3(2.812f,-1.694f,6.277f);

       modified = new Vector3[verts.Length];

       faces = new int[24];

       faces[0] = 0;
       faces[1] = 2;
       faces[2] = 3;
       faces[3] = 0;
       faces[4] = 3;
       faces[5] = 2;

       faces[6] = 1;
       faces[7] = 3;
       faces[8] = 2;
       faces[9] = 1;
       faces[10] = 2;
       faces[11] = 3;

       faces[11] = 0;
       faces[12] = 2;
       faces[13] = 1;
       faces[14] = 0;
       faces[15] = 1;
       faces[16] = 2;
      
       faces[17] = 0;
       faces[18] = 1;
       faces[19] = 3;
       faces[20] = 0;
       faces[21] = 3;
       faces[22] = 1;

    }

    // Update is called once per frame
    void Update()
    {
       angle += increment;

       Matrix4x4 transOrigin = Transforms.MakeTranslate(2.812f, -4.0415f, 6.277f);
       Matrix4x4 transObject = Transforms.MakeTranslate(-2.812f, 4.0415f, -6.277f);
       Matrix4x4 rotate = Transforms.MakeRotateY(angle);

       Matrix4x4 composite = transOrigin * rotate * transObject;

       for (int i=0; i<verts.Length; i++) {
          Vector4 temp = new Vector4(verts[i].x, verts[i].y, verts[i].z, 1);
          modified[i] = composite * temp;
       }

       mesh.vertices = modified;
       mesh.triangles = faces;
    }
}
