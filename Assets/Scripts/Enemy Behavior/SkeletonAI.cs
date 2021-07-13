using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SkeletonAI : EnemyAI
    {
        public Vector2 playerPos;
        public float startRot;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            startRot = rigidBody.rotation;
        }

        // Update is called once per frame
        void Update()
        {
            playerPos = player.position;

        }
        void FixedUpdate()
        {
            Vector2 lookDir = playerPos - rigidBody.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
            rigidBody.rotation = angle + startRot;
        }

        public override void Restart()
        {
            rigidBody.rotation = startRot;
        }
    }
}
