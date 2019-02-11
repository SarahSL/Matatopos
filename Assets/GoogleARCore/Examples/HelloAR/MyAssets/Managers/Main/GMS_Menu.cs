using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMS_Menu : GMS_ControllerState
{
    public InputManager inputManager;
    public string raycastTag;

    public override void Enter()
    {
        m_target.helloARController.menuObject.SetActive(true);
        inputManager = FindObjectOfType<InputManager>();
        raycastTag = "";
        inputManager.TouchAction += MenuState;

    }
    public override void Exit()
    {
        m_target.helloARController.menuObject.SetActive(false);

        inputManager.TouchAction -= MenuState;
    }

    public override void Update()
    {

    }
    private void MenuState(Vector2 hit)
    {
        RaycastHit h;
        if (Physics.Raycast(m_target.helloARController.m_references.FirstPersonCamera.ScreenPointToRay(hit), out h))
        {
            raycastTag = h.collider.tag;
            if (raycastTag == "Game")
            {
                m_target.SM_GoToPlaying();
            }
        }

    }
}
