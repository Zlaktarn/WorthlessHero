using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public RowScript[] row;
    bool startSpin = false;

    public float first;
    public float second;
    public float third;

    public Vector3 vResult;
    public float spinSpeed;
    public float minSpeed;
    public float maxSpeed;
    public float deacceleration;

    public PlayerScript player;
    public Animator pAnim;
    public MonsterScript monster;
    public Animator mAnim;

    public float result;
    public float rollMultiplier = 1;
    public string resultString;

    public AudioClip victoryClip;
    public AudioSource audioSource;

    bool resultChecked = false;

    void Start()
    {
        pAnim = pAnim.GetComponent<Animator>();
        mAnim = mAnim.GetComponent<Animator>();
        audioSource.clip = victoryClip;
    }

    void Update()
    {
        if(!row[0].spin && !row[1].spin && !row[2].spin)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartSpin();

                StartCoroutine(Spinning());
            }
        }

        //first = row[0].result;
        //second = row[1].result;
        //third = row[2].result;
        vResult = new Vector3(row[0].result, row[1].result, row[2].result);


        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayerAttack(2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            BothStrike(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MonsterAttack(1);

        }
        Result();

        Victory();

    }

    void StartSpin()
    {
        if(!startSpin)
        {
            startSpin = true;
        }
    }

    IEnumerator Spinning()
    {
        foreach (RowScript spinner in row)
        {
            spinner.deacceleration = deacceleration;
            spinner.currentSpeed = Random.Range(minSpeed, maxSpeed);
            spinner.spin = true;
        }

        for (int i = 0; i < row.Length; i++)
        {
            //Allow The Reels To Spin For A Random Amout Of Time Then Stop Them
            yield return new WaitForSeconds(Random.Range(2, 4));
            //row[0].stopSpin = true;
            //if(!row[0].spin)
            //{
            //    row[1].stopSpin = true;
            //    if (!row[1].spin)
            //        row[2].stopSpin = true;
            //}
            row[i].stopSpin = true;
            //row[i].Deaccelerate();
        }


        resultChecked = false;
        startSpin = false;
    }

    void Result()
    {
        if (!row[0].spin && !row[1].spin && !row[2].spin)
        {
            if (!resultChecked)
            {
                CheckResult();
                resultChecked = true;
            }
        }
    }

    void CheckResult()
    {
        if (vResult.x == 1 && vResult.y != 1 && (vResult.z != 1 || vResult.z == 1))
        {
            PlayerAttack(1);
            print("Attack1");
        }
        else if (vResult.x == 1 && vResult.y == 1 && vResult.z != 1)
        {
            PlayerAttack(2);
            print("Attack2");

        }
        else if (vResult.x == 1 && vResult.y == 1 && vResult.z == 1)
        {
            PlayerAttack(3);
            print("Attack3");
        }

        else if (vResult.x == 2 && vResult.y != 2 && (vResult.z != 2 || vResult.z == 2))
        {
            MonsterAttack(1);
            print("Struck1");
        }

        else if (vResult.x == 2 && vResult.y == 2 && vResult.z != 2)
        {
            MonsterAttack(2);
            print("Struck2");
        }
        else if (vResult.x == 2 && vResult.y == 2 && vResult.z == 2)
        {
            MonsterAttack(3);
            print("Struck3");
        }

        else if (vResult.x == 3 && vResult.y != 3 && (vResult.z != 3 || vResult.z == 3))
        {
            BothStrike(1);
            print("Both1");
        }

        else if (vResult.x == 3 && vResult.y == 3 && vResult.z != 3)
        {
            BothStrike(2);
            print("Both2");
        }
        else if (vResult.x == 3 && vResult.y == 3 && vResult.z == 3)
        {
            BothStrike(3);
            print("Both3");
        }

        else if (vResult.x == 4 && vResult.y != 4 && (vResult.z != 4 || vResult.z == 4))
        {
            GainXP(1);
        }
        else if (vResult.x == 4 && vResult.y == 4 && vResult.z != 4)
        {
            GainXP(2);
        }
        else if (vResult.x == 4 && vResult.y == 4 && vResult.z== 4)
        {
            GainXP(4);
        }

        else if (vResult.x == 5 && vResult.y != 5 && (vResult.z != 5 || vResult.z == 5))
        {
            Chaos(1);
        }
        else if (vResult.x == 5 && vResult.y == 5 && vResult.z != 5)
        {
            Chaos(2);
        }
        else if (vResult.x == 5 && vResult.y == 5 && vResult.z == 5)
        {
            Chaos(4);
        }
    }

    void PlayerAttack(float x)
    {
        result = player.attackDmg * x * rollMultiplier;
        monster.health -= result;
        rollMultiplier = 1;

        pAnim.SetBool("Attack", true);

        if (monster.health <= 0)
        {
            mAnim.SetBool("Death", true);
            
            pAnim.SetBool("Victory", true);
            audioSource.Play();

        }
        else
        {
            string Struck = "Struck" + Random.Range(1, 3);
            mAnim.SetBool(Struck, true);
        }

        //resultString.text = "Player deals: " + resultString.ToString();
    }

    void MonsterAttack(float x)
    {
        result = monster.attackDmg * x * rollMultiplier;
        player.health -= result;
        int randInt = Random.Range(1, 3);

        string Attack = "Attack" + randInt;
        string Struck = "Struck" + randInt;
        mAnim.SetBool(Attack, true);

        if (player.health > 0)
        {
            pAnim.SetBool(Struck, true);
        }
        else
            pAnim.SetBool("Death", true);


       

        rollMultiplier = 1;
    }


    void BothStrike(float x)
    {
        monster.health -= player.attackDmg * x * rollMultiplier;

        int randInt = Random.Range(1, 3);
        string Attack = "Attack" + randInt;
        string Struck = "Struck" + randInt;

        if (monster.health > 0)
        {
            player.health -= monster.attackDmg * x * rollMultiplier;
            pAnim.SetBool("Attack", true);
            pAnim.SetBool(Struck, true);
            mAnim.SetBool(Attack, true);
            mAnim.SetBool(Struck, true);

        }
        else
        {
            pAnim.SetBool("Attack", true);
            pAnim.SetBool("Victory", true);
            audioSource.Play();

            mAnim.SetBool("Death", true);
        }

        rollMultiplier = 1;
    }

    void GainXP(float x)
    {
        result = x * rollMultiplier + player.intelligence;
        


        player.xp += result;
        if (player.xp >= player.xpToLevel)
            player.levelUp = true;

        if (player.levelUp)
            pAnim.SetBool("Level", true);
        else
            pAnim.SetBool("XP", true);

        rollMultiplier = 1;
    }
    void Chaos(float x)
    {
        result = x * rollMultiplier;
        rollMultiplier = result;
        mAnim.SetBool("Chaos", true);
    }
    
    void Victory()
    {
        if(monster.health <= 0)
        {
        }
    }
}
