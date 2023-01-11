using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    public float force = 20;
    public float force_air = 20;
    Rigidbody2D rb;
    Detectordesuelo ground;
    int jumps;
    public int jumps_max = 2;
    movimientohorizontal movi;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<Detectordesuelo>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (ground.grounded)
        {
            jumps = jumps_max;
        }



        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            jumps--;

            if (ground.grounded)
            {
                rb.AddForce(new Vector2(0, force));
            }
            
            else
            {
                rb.AddForce(new Vector2(0, force_air));
            }
            
            
        }

        
    }

    
}
