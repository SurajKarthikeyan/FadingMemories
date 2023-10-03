using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorToCrosshair : MonoBehaviour
{

    private DialogueMenuSelection menuSelection;

    private FirstPersonController playerController;

    public GameObject player;

    //private int x;
    // Start is called before the first frame update
    void Start()
    {
        menuSelection = player.GetComponent<DialogueMenuSelection>();
        playerController = player.GetComponent<FirstPersonController>();
        CursorToCrosshairSet();
        //x = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CursorToCrosshairSet()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
        playerController.RotationSpeed = menuSelection.playerRotationSpeed;
    }
}
