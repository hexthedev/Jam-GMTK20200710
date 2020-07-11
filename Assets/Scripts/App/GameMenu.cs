using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public BlackHoleControl blackhole;
    public bool isMenuActive = false;

    public void Update()
    {
        if(Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame) MenuToggle();
        if(Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame) MenuToggle();
    }

    public void MenuToggle()
    {
        if (!isMenuActive)
        {
            menu.SetActive(true);
            isMenuActive = true;

            foreach(ForceObject obj in ForceManager.ForceReceivers)
            {
                obj.Pause();
            }

            ForceManager.IsPaused = true;
            blackhole.Pause();
        }
        else
        {
            menu.SetActive(false);
            isMenuActive = false;

            foreach (ForceObject obj in ForceManager.ForceReceivers)
            {
                obj.UnPause();
            }

            ForceManager.IsPaused = false;
            blackhole.UnPause();
        }
    }
}
