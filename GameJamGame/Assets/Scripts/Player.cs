using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHealth = 150, currHealth;
    public bool isOnTurn = false;
    public GameObject[] slots;
    public int[] slotValues;
    public GameObject spell;
    private Transform playerHand;
    public Selector mouse;
    public int stun = 0;
    public bool hasRolled = false;
    private GameObject cubeSpawner;
    private GameObject manager;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        cubeSpawner = GameObject.FindGameObjectWithTag("Spawner");
        mouse = transform.GetChild(1).GetComponent<Selector>();
        slots = new GameObject[3];
        slotValues = new int[3];
        slots[0] = transform.GetChild(2).GetChild(0).gameObject;
        slots[1] = transform.GetChild(2).GetChild(1).gameObject;
        slots[2] = transform.GetChild(2).GetChild(2).gameObject;
        currHealth = startHealth;
        playerHand = transform.GetChild(0);
    }

    void Update()
    {
        slotValues[0] = slots[0].GetComponent<Slot>().num;
        slotValues[1] = slots[1].GetComponent<Slot>().num;
        slotValues[2] = slots[2].GetComponent<Slot>().num;

        if (!isOnTurn)
            for (int i = 0; i < 3; i++)
                transform.GetChild(i).gameObject.SetActive(false);
        else
            for (int i = 0; i < 3; i++)
                transform.GetChild(i).gameObject.SetActive(true);

        if (isOnTurn && stun < 25)
        {
            if (stun < 0)
                stun = 0;
            if (!hasRolled)
            {
                cubeSpawner.GetComponent<CubeTest>().RollDice();
                cubeSpawner.GetComponent<CubeTest>().RollDice();
                cubeSpawner.GetComponent<CubeTest>().RollDice();
                hasRolled = true;
            }
        }

        print(currHealth);
    }
    public void CombineDice()
    {
        //GameObject spellObj = Instantiate(spell, playerHand, false);

        for (int i = 0; i < 3; i++)
        {
            slots[i].GetComponent<Slot>().currObj = null;
            Destroy(slots[i].GetComponent<Slot>().currObj);
        }

        this.gameObject.GetComponent<Spell>().Create(slotValues[0], slotValues[1], slotValues[2]);
        this.gameObject.GetComponent<Spell>().Cast();
        print("t");
    }
}
