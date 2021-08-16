using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TeleportPredictor : MonoBehaviour
    {

        private SpriteRenderer spriteRenderer;
        private GameObject player;
        private PlayerMovement mover;
        private PlayerTeleport teleporter;
        private Vector2 direction;
        private bool on = false;

        void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
            player = gameObject.transform.parent.gameObject;
            mover = player.GetComponent<PlayerMovement>();
            teleporter = player.GetComponent<PlayerTeleport>();
            //SpriteRenderer.color = new Color(1f, 1f, 1f, .5f)
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                on = true;
            } 
            if (Input.GetKeyUp(KeyCode.Space))
            {
                on = false;
            }
            if (on && teleporter.CanTeleport())
            {
                direction = mover.GetDirection();
                transform.position = player.transform.position;
                transform.Translate(direction.normalized * teleporter.GetDistance());
                spriteRenderer.enabled = true;
            }
            else
            {
                spriteRenderer.enabled = false;
            }
        }
    }
}
