using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Shooting : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject arrowPrefab;
        public float arrowForce = 5f;

        public float shootCoolDown = 4f;
        private float shootTimer;

        // Start is called before the first frame update
        void Start()
        {
            shootTimer = shootCoolDown;
            firePoint = this.gameObject.transform.GetChild(0);
        }

        // Update is called once per frame
        void Update()
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootCoolDown;
            }
        }
        void Shoot()
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            rb.rotation += 90f;
            rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        }
    }
}
