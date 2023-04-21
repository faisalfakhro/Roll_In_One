using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    Animator animator;
    public GameObject roller;
    int vnum = 2;
    float x0 = -9.3f;
    float mindt = 0.3f;
    float mtimer = 5f;
    float cooldown = 1f;
    float stimer = 5f;
    public int score = 0;
    public float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mtimer += Time.deltaTime;
        stimer += Time.deltaTime;
        time += Time.deltaTime;

        // shoot
        if (stimer > cooldown)
        {
            if (Input.GetButton("Jump"))
            {
                stimer = 0f;
                animator.SetTrigger("OnFlick");
                GameObject stationary = GameObject.Find("StationaryDice");
                stationary.GetComponent<StationaryDiceController>().timer2 = 0f;

                var position = new Vector2(x0 + 2.35f, transform.position.y - 0.4f);
                var newroller = Instantiate(roller, position, Quaternion.identity);
                newroller.GetComponent<Animator>().SetFloat("Offset", stationary.GetComponent<StationaryDiceController>().state / 4f);
                newroller.GetComponent<RollController>().orinum = stationary.GetComponent<StationaryDiceController>().state;
            }
        }

        // move
        if (mtimer > mindt && stimer > cooldown)
        {
            float vertical = Input.GetAxis("Vertical");
            int dy = 0;

            if (vertical > 0.1f)
            {
                dy = 1;
            }
            else if (vertical < -0.1f)
            {
                dy = -1;
            }

            if (dy != 0 && vnum + dy <= 2 && vnum + dy >= 0)
            {
                mtimer = 0f;
                vnum += dy;
            }
        }

        transform.position = new Vector2(x0, -3.0f + (3.5f * vnum));
    }
}