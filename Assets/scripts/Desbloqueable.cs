using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desbloqueable : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    movimientohorizontal movimientohorizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void muerte()
    {
        Destroy(gameObject);
    }

    
    
}
