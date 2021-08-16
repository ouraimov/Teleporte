using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TeleportMarker : MonoBehaviour
    {

        private Animator animator;
        private PlayerTeleport teleporter;
        private bool ready = true;


        // Start is called before the first frame update
        void Start()
        {
            teleporter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTeleport>();
            animator = GetComponent<Animator>();
            ready = true;
        }

        // Update is called once per frame
        void Update()
        {
            animator.enabled = ready;
        }
    }
}

