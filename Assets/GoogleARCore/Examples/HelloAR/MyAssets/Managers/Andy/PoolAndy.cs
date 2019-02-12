using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAndy : MonoBehaviour
{
    public PoolAndyControllerInstanciables m_instanciables;
    private GameObject[] points;
    private bool[] pointsUsed = new bool[20];
    private AndyAgent andyAgentComponent;
    void Start()
    {
        
    }

    // Update is called once per frame
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
        CreateAndy(5);
    }

    private void CreateAndy(int amount)
    {
        for(int i =1; i < amount; i++)
        {
            int pos = RandomPos();
            pointsUsed[pos] = true;
            var andy = Instantiate(m_instanciables.AndyPrefab, points[pos].transform.position, Quaternion.identity);

            andy.transform.localScale = new Vector3(1f, 1F, 1F);
            andyAgentComponent = andy.GetComponent<AndyAgent>();
            andyAgentComponent.id_pos = pos;
        }
    }

    private int RandomPos()
    {
        int result = UnityEngine.Random.Range(1, 21);
        while (pointsUsed[result] == true)
        {
            result = UnityEngine.Random.Range(1, 21);
        }
        return result;
    }

    [System.Serializable]
    public class PoolAndyControllerInstanciables
    {
        public GameObject AndyPrefab;
    }
}
