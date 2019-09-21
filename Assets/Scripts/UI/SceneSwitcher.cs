using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void ChangeScene(int SceneIndx)
    {
        LevelLoader.LoadAnyLevel(SceneIndx);
    }
}
