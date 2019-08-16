using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtension
{
    public static Vector3 SetY(this Vector3 vec3,float yval)
    {
        return new Vector3(vec3.x,yval , vec3.z);
    }
    public static Vector3 SetX(this Vector3 vec3, float xval)
    {
        return new Vector3(xval, vec3.y, vec3.z);
    }
    public static Vector3 SetZ(this Vector3 vec3, float zval)
    {
        return new Vector3(vec3.x, vec3.y, zval);
    }
    public static Vector3 SetRandomVectorXYZ(this Vector3 vec3,float Xmin,float Xmax,float Ymin , float Ymax,float Zmin,float Zmax)
    {
        float x = Random.Range(Xmin, Xmax);
        float y = Random.Range(Ymin, Ymax);
        float z = Random.Range(Zmin, Zmax);
        return new Vector3(x, y, z);
    }
}

