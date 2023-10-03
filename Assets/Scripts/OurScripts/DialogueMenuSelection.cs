using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMenuSelection : MonoBehaviour
{
    FirstPersonController playerController;

    public float playerRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<FirstPersonController>();
        playerRotationSpeed = playerController.RotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuSelection()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.RotationSpeed = 0;
    }
}
