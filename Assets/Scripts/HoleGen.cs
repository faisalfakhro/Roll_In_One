using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleGen : MonoBehaviour
{
    public GameObject flagpole1;
    public GameObject flagpole2;
    public GameObject flagpole3;
    public GameObject flagpole4;
    public GameObject[] flagpoles;
    float x0 = -2.7f;
    float dx = 3.6f;
    float y0 = 5f;
    float dy = -3.5f;
    public bool[,] taken = new bool[4,3];

    // Start is called before the first frame update
    void Start()
    {
        flagpoles = new GameObject[] { flagpole1, flagpole2, flagpole3, flagpole4 };
        newHole();
        newHole();
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for(int i = 0; i < taken.GetLength(0); i++)
        {
            for(int j = 0; j < taken.GetLength(1); j++)
            {
                if (taken[i, j]) count++;
            }
        }

        if (count < 2)
        {
            newHole();
        }
    }

    void newHole()
    {
        int num = Random.Range(0, 4);
        int xnum, ynum;

        do
        {
            xnum = Random.Range(0, 4);
            ynum = Random.Range(0, 3);
        } while (taken[xnum, ynum]);


        taken[xnum, ynum] = true;
        var position = new Vector2(x0 + xnum * dx, y0 + ynum * dy);
        var hole = Instantiate(flagpoles[num], position, Quaternion.identity);
        hole.GetComponent<Flagpole>().x = xnum;
        hole.GetComponent<Flagpole>().y = ynum;
        hole.GetComponent<Flagpole>().num = num;
    }
}
