using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAndy : MonoBehaviour
{
    public PoolAndyControllerInstanciables m_instanciables;
    public GameObject[] points;
    private bool[] pointsUsed;
    private int count;
    

    private AndyAgent andyAgentComponent;
    private void Awake()
    {
        pointsUsed = new bool[20];
        count = 0;
    }
    void Update()
    {
        if(points.Length == 0)
        {
            points = GameObject.FindGameObjectsWithTag("Point");
            CreateFirstAndy();
        }

    }

    private void CreateFirstAndy()
    {

        Debug.Log("CREATE FIRST ANDY");
        CreateAndy(5);
    }
    public void DeathAndy(int posAndy)
    {
        pointsUsed[posAndy] = false;
        count--;
        if (count < 3)
        {
            CreateAndy(3);
        }
    }
    private void CreateAndy(int amount)
    {
        for(int i =1; i <= amount; i++)
        {
            int pos = RandomPos();
            pointsUsed[pos] = true;
            var andy = Instantiate(m_instanciables.AndyPrefab, points[pos].transform.position, Quaternion.identity);
            andyAgentComponent = andy.GetComponent<AndyAgent>();
            andyAgentComponent.id_pos = pos;
            andy.SetActive(true);
            count = 5;
        }
    }
    public void GameOver()
    {
        pointsUsed = new bool[20];
        points = null;
    }
    private int RandomPos()
    {
        int result = UnityEngine.Random.Range(1, 20);
        while (pointsUsed[result] == true)
        {
            result = UnityEngine.Random.Range(1, 20);
        }
        return result;
    }

    [System.Serializable]
    public class PoolAndyControllerInstanciables
    {
        public GameObject AndyPrefab;
    }
}
