using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD_Death : AD_AndyControllerState
{
    PoolAndy poolAndy;
    public override void Enter()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaa" + m_target.gameObject.name);
        poolAndy = FindObjectOfType<PoolAndy>();
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaa" + poolAndy);
        poolAndy.DeathAndy(m_target.id_pos);
       
        
    }

    public override void Exit()
    {
        m_target.gameObject.SetActive(false);
    }

    public override void Update()
    {
        m_target.SM_GoToInactive();
    }
}
