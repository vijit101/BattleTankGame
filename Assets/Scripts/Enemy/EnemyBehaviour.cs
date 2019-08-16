using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            int lives = PlayerPrefs.GetInt("Lives");
            if (lives < 1)
            {
                //Game Over
                Debug.Log("Player Dead");
            }
            else
            {
                lives--;
                PlayerPrefs.SetInt("Lives", lives);
                PlayerPrefs.SetInt("Respawn", 1);
            }
        }
        
    }
}

