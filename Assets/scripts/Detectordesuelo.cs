using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectordesuelo : MonoBehaviour
{
    public bool grounded;
    public float length = 1;
    public LayerMask Mask;

    public List<Vector3> originPoints;

    private void Update()
    {
        grounded = false;
        


        for (int i = 0; i < originPoints.Count; i++)
        {
            Debug.DrawRay(transform.position + originPoints[i], Vector3.down * length, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + originPoints[i], Vector3.down, length, Mask);
            if (hit.collider != null)
            {
                
                if (hit.collider.tag == "plataforma_movil")
                {
                    transform.parent = hit.transform;
                }

                Debug.DrawRay(transform.position + originPoints[i], Vector3.down * hit.distance, Color.green);
                grounded = true;
            }

            if (!grounded)
            {
                transform.parent = null;
            }
        }
    }

    

}

