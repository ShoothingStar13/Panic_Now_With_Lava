using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ground_Script : MonoBehaviour

{
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroR;
    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer < agroR)
        {
            ChasePlayer();
        }
        else
        {
            StopChasePlayer();
        }
        
    }

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed,0);
            transform.localScale = new Vector2 (-1,1);
        }
        else if(transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed,0);
            transform.localScale = new Vector2 (1,1);
        }
    }
    private void StopChasePlayer()
    {
        rb2d.velocity = new Vector2 (0,0);
        
    }
}
