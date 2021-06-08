using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SmoothCamera2D : MonoBehaviour
    {

        public float dampTime;
        private Vector3 velocity = Vector3.zero;
        public Transform target;
        //public Camera camera;

        private const float CAMERA_HEIGHT = 10f;

        // Start is called before the first frame update
        void Start()
        {
            dampTime = 0.25f;
            transform.position = new Vector3(0, 0, -CAMERA_HEIGHT);
        
            Camera.main.fieldOfView = 45f;
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (target)
            {
                Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
                Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
        }
    }
}
