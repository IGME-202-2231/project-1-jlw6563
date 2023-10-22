using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();
    float timer = 1;
    int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
