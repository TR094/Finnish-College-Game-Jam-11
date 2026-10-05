using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class CoreRespawner : MonoBehaviour
{


    public GameObject CoreBallPrefab;
    public float respawnTime = 1.0f;

    public void spawnCore()
    {

        GameObject a = Instantiate(CoreBallPrefab) as GameObject;
        a.transform.position = Vector2.zero;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }






    // Update is called once per frame
    void Update()
    {
        //Invoke("spawnCore", 1);
        //five hundred balls

    }
}
