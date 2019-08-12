using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtension
{
    public static Vector3 SetY(this Vector3 vec3,float yval)
    {
        return new Vector3(vec3.x,yval , vec3.z);
    }
}

