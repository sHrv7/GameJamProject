using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Player[] players;
    public List<Player> targets;
    private Selector mouse;
    private Manager manager;
    public int power;
    private int modSel, tarSel;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }
    public void Create(int target, int type, int mod)
    {
        modSel = mod;
        tarSel = target;
        int z = 0;
        foreach (GameObject go in GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().players)
        {
            players[z] = go.GetComponent<Player>();
            z++;
        }
        mouse = transform.parent.parent.GetComponent<Player>().mouse;
        SelectTarget(target);
        SelectType(type);
        SelectMod(mod);
    }

    void SelectTarget(int tar)
    {
        switch (tar)
        {
            case 1:
                targets.Add(players[Random.Range(1, players.Length)]);
                break;
            case 2:
                Player enemy;
                enemy = players[Random.Range(1, players.Length)];
                while (enemy == transform.parent.parent)
                {
                    enemy = players[Random.Range(1, players.Length)];
                }
                targets.Add(enemy);
                break;
            case 3:
                break;
            case 4:
                targets.Add(transform.parent.parent.GetComponent<Player>());
                break;
            case 5:
                for (int i = 0; i < manager.players.Length; i++)
                {
                    targets.Add(players[i]);
                }
                break;
            case 6:
                for (int i = 0; i < manager.players.Length; i++)
                {
                    if (manager.players[i] != transform.parent.parent)
                        targets.Add(players[i]);
                }
                break;
            default:
                break;
        }
    }
    void SelectType(int typ)
    {
        switch (typ)
        {
            case 1:
                power = 1;
                break;
            case 2:
                power = 2;
                break;
            case 3:
                power = 0;
                break;
            case 4:
                power = 3;
                break;
            case 5:
                power = 3;
                break;
            case 6:
                power = 5;
                break;
            default:
                break;
        }
    }
    void SelectMod(int mod)
    {
        switch (mod)
        {
            case 1:
                power += 1;
                break;
            case 2:
                power += 2;
                break;
            case 3:
                power *= 2;
                break;
            case 4:
                power = (power + 1) * 2;
                break;
            case 5:
                power = (power + 3) * 2;
                break;
            case 6:
                power = (power + 2) * 3;
                break;
            default:
                break;
        }

    }
    Player SelectEnemy()
    {
        Player enemy;
        enemy = mouse.selectedEnemy;
        return enemy;
    }
    public void Cast()
    {
        if (tarSel == 3)
            targets.Add(SelectEnemy());

        foreach (Player target in targets)
        {
            switch (modSel)
            {
                case 1:
                    target.currHealth -= power;
                    break;
                case 2:
                    if (target.currHealth + power <= target.startHealth)
                        target.currHealth += power;
                    else
                        target.currHealth = target.startHealth;
                    break;
                case 3:
                    target.currHealth -= 2 * power;
                    break;
                case 4:
                    target.currHealth += power;
                    break;
                case 5:
                    target.currHealth -= power;
                    break;
                case 6:
                    target.stun += power;
                    break;
                default:
                    break;
            }
        }
    }
}
