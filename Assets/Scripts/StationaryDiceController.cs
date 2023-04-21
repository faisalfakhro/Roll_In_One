using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryDiceController : MonoBehaviour
{
    public GameObject hand;
    BoxCollider2D collider;
    Animator animator;
    public int state = 0;
    float timer = 0f;
    float T = 0.5f;
    float dx = 2.35f;
    float dy = -0.3f;
    public float timer2 = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer > T)
        {
            timer = 0;
            state = (state + 1) % 4;
        }
        animator.SetInteger("state", state + 1);

        if (timer2 > 1f)
        {
            transform.position = new Vector2(hand.transform.position.x + dx,
            hand.transform.position.y + dy);
        } else
        {
            transform.position = new Vector2(0,
            20);
        }
        
    }
}
