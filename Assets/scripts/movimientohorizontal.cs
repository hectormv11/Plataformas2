using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientohorizontal : MonoBehaviour
{
    public int recogidas;
    public float speed = 3.5f;
    Detectordesuelo ground;
    Animator animator;
    LifeController life;
    public GameObject llave;
    public int llaves;
    public Transform spawn;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        ground = GetComponent<Detectordesuelo>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        

        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontal * Time.deltaTime * speed, 0);

        animator.SetBool("grounded", ground.grounded);
        animator.SetBool("moving", horizontal != 0);
        

        if(horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(recogidas > 5)
        {

            if (Input.GetMouseButtonDown(0))
            {
                speed = 5f;
            }
        }

        if (Input.GetMouseButton(1))
        {
            speed = 3.5f;
        }

        
        
            
        
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Moneda")
        {
            recogidas++;
        }

        if (collision.tag == "Puerta")
        {
            

            if (llaves == 1)
            {
                
                transform.position = spawn.position;
                collision.gameObject.GetComponent<Desbloqueable>().muerte();
                
            }
        }

        if (collision.tag == "Lave1")
        {
            collision.gameObject.GetComponent<llaveantes>().muerte();
            llaves++;
        }

    }

    
}
