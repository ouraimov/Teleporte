using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TeleportMarker : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private PlayerTeleport teleporter;

        // Start is called before the first frame update
        void Start()
        {
            teleporter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTeleport>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            spriteRenderer.enabled = teleporter.TeleportReady();
        }
    }
}

