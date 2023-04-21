using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollController : MonoBehaviour
{
    float velocity = 7.35f;
    public int orinum;
    int state = 0;
    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            transform.position = new Vector2(transform.position.x + velocity * Time.deltaTime,
            transform.position.y);
        }

        Collider2D[] result = new Collider2D[1];
        ContactFilter2D filter = new ContactFilter2D();
        filter = filter.NoFilter();
        int col = collider.OverlapCollider(filter, result);

        if (col > 0)
        {
            GameObject flag = result[0].transform.gameObject;
            if (flag.GetComponent<Flagpole>().num == (orinum + flag.GetComponent<Flagpole>().x + 1) % 4)
                GameObject.Find("HandFlick").GetComponent<HandController>().score++;
            GameObject.Find("HoleGen").GetComponent<HoleGen>().taken[flag.GetComponent<Flagpole>().x, flag.GetComponent<Flagpole>().y] = false;
            Destroy(flag);
            Destroy(this.transform.gameObject);
        }
    }
}
