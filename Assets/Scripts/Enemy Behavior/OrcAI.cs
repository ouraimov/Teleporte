using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class OrcAI : EnemyAI
    {
        private Vector2 direction;
        private UnityEngine.AI.NavMeshAgent agent;
        void Update()
        {

            if(GameManager.instance.GameIsOver() || !GameManager.instance.GameMove())
            {
                return;
            }            
        }

        public override void Restart()
        {
            transform.position = startPos;
        }

        public void Deletus()
        {
            agent.destination = transform.position;
            print("yup");
        }
    }
}
