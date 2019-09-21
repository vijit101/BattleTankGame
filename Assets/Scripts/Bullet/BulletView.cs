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
            //damage logic via interface to call damage function on the damagable obj.   
            if (collision.GetComponent<IDamagable>() != null)
            {
                IDamagable damagable = collision.GetComponent<IDamagable>();
                damagable.TakeDamage(bulletcontroller.BulletModel.Damage);
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

