using System.Collections;
using System.Collections.Generic;
using Tanks.interfaces;
using UnityEngine;

namespace Tanks.Bullet
{   
    public class BulletView : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            /*if (collision.gameObject.tag == "Enemy")
            {
                float score = PlayerPrefs.GetFloat("Score");
                score++;
                PlayerPrefs.SetFloat("Score", score);
                Destroy(gameObject);
            }*/
            //damage logic via interface to call damage function on the damagable obj.   
            if (collision.GetComponent<IDamagable>() != null)
            {
                //collision.gameObject.TakeDamage();
                IDamagable damagable = collision.GetComponent<IDamagable>();
                damagable.TakeDamage(bulletcontroller.BulletModel.Damage);
                //Destroy(gameObject);
                // Add score logic
            }
        }
        public BulletType bulletType;
        public float Speed = 50;
        private BulletController bulletcontroller;
        float timespan;

        void Update()
        {
            transform.Translate(transform.forward *Speed * Time.deltaTime);
            //Destroy(gameObject, .6f);
            // return bullet to pool logic
            if (timespan > .6)
            {
                bulletcontroller.ReturnToPool();
                this.gameObject.SetActive(false);
                timespan = 0;
            }
            else
            {
                timespan += Time.deltaTime;
            }
        }
        public void InitializeController(BulletController bulletController)
        {
            this.bulletcontroller = bulletController;
        }
    }

}

