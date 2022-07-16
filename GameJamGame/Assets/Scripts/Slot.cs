using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject currObj;
    public int num;
    bool hold = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dice")
        {
            Destroy(currObj);
            currObj = other.gameObject;
        }
    }
    void Update()
    {
        if (currObj != null)
        {
            if (hold)
            {
                currObj.GetComponent<Collider>().isTrigger = false;
                currObj.transform.position = transform.position;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                hold = true;

                if (currObj.TryGetComponent<DiceNum>(out DiceNum dn))
                    num = dn.diceNum;

                //rotiranje kocke da je lijepo u kucici
                switch (num)
                {
                    case 1:
                        currObj.transform.eulerAngles = new Vector3(180, 0, 0);
                        break;
                    case 2:
                        currObj.transform.eulerAngles = new Vector3(270, 0, 0);
                        break;
                    case 3:
                        currObj.transform.eulerAngles = new Vector3(0, 90, 0);
                        break;
                    case 4:
                        currObj.transform.eulerAngles = new Vector3(0, 270, 0);
                        break;
                    case 5:
                        currObj.transform.eulerAngles = new Vector3(0, 90, 90);
                        break;
                    case 6:
                        currObj.transform.eulerAngles = new Vector3(0, 0, 0);
                        break;
                }
            }


        }

    }
}
