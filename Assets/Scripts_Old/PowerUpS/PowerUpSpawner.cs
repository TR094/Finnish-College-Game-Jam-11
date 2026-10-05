using NUnit.Framework.Constraints;
using System;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PowerUpSpawner : MonoBehaviour
{


    public GameObject ballsplittwo;
    public GameObject ballsplitthree;
    public GameObject ballonehp;
    public GameObject balltwohp;
    public float respawnTime2split;
    public float respawnTime3split;
    public float respawnTimeonehp;
    public float respawnTimetwohp;



    public float coreballspeed;



    float timer;
    Vector2 pos;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coreballspeed = 5f;
        StartCoroutine(powerupRandom2split());
        StartCoroutine(powerupRandom3split());
        StartCoroutine(powerup1HP());
        StartCoroutine(powerup2HP());
    }
    void Update()
    {
        //Invoke("spawnCore", 1);
        //five hundred balls

        if (respawnTime2split <= 2)
        {
            respawnTime2split = 2f;
        }

        if (respawnTime3split <= 2)
        {
            respawnTime3split = 2f;
        }

        if (respawnTimetwohp <= 1)
        {
            respawnTimetwohp = 0.1f;
        }

        if (respawnTimeonehp <= 1)
        {
            respawnTimeonehp = 0.1f;
        }


        if (timer < 5)
        {
            timer = timer + Time.deltaTime;
        }
        //else if (timer < 30)
        //{
        //}
        else
        {
            timer = 0;


            respawnTimetwohp += 0.1f;
            respawnTimeonehp += 0.1f;
            respawnTime2split -= 0.5f;
            respawnTime3split -= 0.5f;

            coreballspeed += 0.1f;

        }


        int month = UnityEngine.Random.Range(-3, 3);
        pos = new Vector2(month, 5f);

    }
    public void spawnCore2split()
    {

        GameObject a = Instantiate(ballsplittwo) as GameObject;
        a.transform.position = pos;

    }

    public void spawnCore3split()
    {

        GameObject a = Instantiate(ballsplitthree) as GameObject;
        a.transform.position = pos;

    }
    public void spawn1HP()
    {

        GameObject a = Instantiate(ballonehp) as GameObject;
        a.transform.position = pos;

    }

    public void spawn2HP()
    {

        GameObject a = Instantiate(balltwohp) as GameObject;
        a.transform.position = pos;

    }

    // Update is called once per frame
    IEnumerator powerupRandom2split()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime2split);
            spawnCore2split();
        }
    }

    IEnumerator powerupRandom3split()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime3split);
            spawnCore3split();
        }
    }

    IEnumerator powerup1HP()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTimeonehp);
            spawn1HP();
        }
    }

    IEnumerator powerup2HP()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTimetwohp);
            spawn2HP();
        }
    }
}
