using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtension
{
    public static Vector3 SetZVal(this Vector3 vec3,float zval)
    {
        return new Vector3(vec3.x, vec3.y, zval);
    }
}

