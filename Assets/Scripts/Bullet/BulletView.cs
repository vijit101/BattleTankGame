using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Bullet
{
    
    public class BulletView : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                float score =  PlayerPrefs.GetFloat("Score");
                score++;
                PlayerPrefs.SetFloat("Score", score);
                Destroy(gameObject);
            }
        }
        public BulletType bulletType;
        public float Speed = 50;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(transform.forward * Speed * Time.deltaTime);
        }
    }

}

