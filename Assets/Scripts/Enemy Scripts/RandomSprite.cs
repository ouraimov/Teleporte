using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RandomSprite : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] sprites;
        private SpriteRenderer spriteRenderer;
        //private rand rnd = new Random();

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            //int i = rnd.Next(sprites.Length);
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
