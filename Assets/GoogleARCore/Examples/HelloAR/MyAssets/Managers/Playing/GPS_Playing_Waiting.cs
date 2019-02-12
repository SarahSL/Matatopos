using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GPS_Playing_Waiting : GPS_GamePlayingState
{
    public InputManager inputManager;
    string raycastTag;

    public override void Enter()
    {
        inputManager = FindObjectOfType<InputManager>();
        raycastTag = "";
        inputManager.TouchAction += SelectTruck;
    }
    public override void Exit()
    {
        inputManager.TouchAction -= SelectTruck;
    }
    public override void Update()
    {
        
    }
    private void SelectTruck(Vector2 hit)
    {
        RaycastHit h;
        if (Physics.Raycast(m_target.helloARController.m_references.FirstPersonCamera.ScreenPointToRay(hit), out h))
        {
            raycastTag = h.collider.tag;
            if (raycastTag == "Andy")
            {
               /* m_target.truckSelected = h.collider.gameObject;
                truckAgent = m_target.truckSelected.GetComponent<TruckAgent>();
                truckAgent.agent = h.collider.gameObject.GetComponent<NavMeshAgent>();
                truckAgent.SM_GoToSelected();
                m_target.GPS_GoToPlaying_TruckSelected();*/
            }
        }

    }
}
