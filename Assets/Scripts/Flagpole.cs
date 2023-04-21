using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagpole : MonoBehaviour
{
    public int num;
    public int x = 0;
    public int y = 0;

    // Start is called before the first frame update
    void Start()
    {
        var sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 2 + y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
