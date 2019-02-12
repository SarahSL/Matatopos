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
        inputManager.TouchAction += SelectAndy;
    }
    public override void Exit()
    {
        inputManager.TouchAction -= SelectAndy;
    }
    public override void Update()
    {
        
    }
    private void SelectAndy(Vector2 hit)
    {
        RaycastHit h;
        if (Physics.Raycast(m_target.helloARController.m_references.FirstPersonCamera.ScreenPointToRay(hit), out h))
        {
            raycastTag = h.collider.tag;
            if (raycastTag == "Andy")
            {
                h.collider.gameObject.GetComponent<AndyAgent>().SM_GoToDeath();
            }
        }

    }
}
