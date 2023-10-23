using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteVal : MonoBehaviour
{
    //Holds the size of the box of each sprite.
    Vector2 rectSize;
    
    // Sets the rect size
    void Start()
    {
        rectSize = GetComponent<SpriteRenderer>().bounds.extents * 1.5f;
    }

    /// <summary>
    /// Geters for rectMin
    /// </summary>
    public Vector2 RectMin
    {
        get
        {
            return (Vector2)transform.position - (rectSize / 2);
        }
    }
    /// <summary>
    /// Getter for rectMax
    /// </summary>
    public Vector2 RectMax
    {
        get
        {
            return (Vector2)transform.position + (rectSize / 2);
        }
    }

    /// <summary>
    /// Draws boxes for debugging
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, rectSize);
    }
}
