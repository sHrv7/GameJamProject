using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNum : MonoBehaviour
{
    public int diceNum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit licemPremaDnu;
        // 2 - 5 / gore dolje
        if (Physics.Raycast(transform.position, transform.up, out licemPremaDnu, 0.51f))
        {
            if (licemPremaDnu.transform.tag == "Plane")
                diceNum = 5;
        }
        if (Physics.Raycast(transform.position, -transform.up, out licemPremaDnu, 0.51f))
        {
            if (licemPremaDnu.transform.tag == "Plane")
                diceNum = 2;
        }
        //1 - 6 / naprijed nazad
        if (Physics.Raycast(transform.position, transform.forward, out licemPremaDnu, 0.51f))
        {
            if (licemPremaDnu.transform.tag == "Plane")
                diceNum = 6;
        }
        if (Physics.Raycast(transform.position, -transform.forward, out licemPremaDnu, 0.51f))
        {
            if (licemPremaDnu.transform.tag == "Plane")
                diceNum = 1;
        }
        //3-4 / desno lijevo
        if (Physics.Raycast(transform.position, transform.right, out licemPremaDnu, 0.51f))
        {
            if (licemPremaDnu.transform.tag == "Plane")
                diceNum = 4;
        }
        if (Physics.Raycast(transform.position, -transform.right, out licemPremaDnu, 0.51f))
        {
            if (licemPremaDnu.transform.tag == "Plane")
                diceNum = 3;
        }
    }
}
