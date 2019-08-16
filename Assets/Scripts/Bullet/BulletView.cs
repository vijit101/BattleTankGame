using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Bullet
{   
    public class BulletView : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                float score = PlayerPrefs.GetFloat("Score");
                score++;
                PlayerPrefs.SetFloat("Score", score);
                Destroy(gameObject);
            }

        }
        public BulletType bulletType;
        public float Speed = 50;

        void Update()
        {
            transform.Translate(transform.forward *Speed * Time.deltaTime);
            Destroy(gameObject, .6f);
        }
    }

}

