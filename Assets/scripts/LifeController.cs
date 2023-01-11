using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static lifetaker;

public class LifeController : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencible_time;
    public bool invencible;
    movimientohorizontal movi;

    public enum DeathMode { Teleport, ReloadScreen, Destroy }
    public DeathMode death_mode;

    public Transform respawn;

    Rigidbody2D rb;



    public TextMeshProUGUI vidas;
    public TextMeshProUGUI monedas;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        lifes_current = lifes_max;
    }

    public void Update()
    {
        
    }
    public void Damage(int damage, bool ignoreInvencible = false)
    {
        if (!invencible || ignoreInvencible)
        {
            lifes_current -= damage;
            StartCoroutine(Invencible_corrutine());
            if (lifes_current <= 0)
            {
                Death();
            }
        }
        
    }
    
    public void Death()
    {
        switch (death_mode)
        {
            case DeathMode.Teleport:
                rb.velocity = new Vector2(0, 0);
                transform.position = respawn.position;
                lifes_current = lifes_max;
                break;
            case DeathMode.ReloadScreen:
                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }



    IEnumerator Invencible_corrutine()
    {
        
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
        
    }
}
