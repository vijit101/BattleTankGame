using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader 
{
    public static void LoadAnyLevel(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
