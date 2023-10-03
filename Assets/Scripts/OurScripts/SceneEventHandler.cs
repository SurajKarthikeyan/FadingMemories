using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using StarterAssets;

public class SceneEventHandler : MonoBehaviour, IInteractable
{
    //public GameObject interactObject;

    private Flowchart flowchart;
    public Flowchart currentDayFlowchart;
    private float playerMoveSpeed;
    private float playerRotationSpeed;
    public FirstPersonController playerMovement;

    //public GameObject dropOff;


    public void Interact(GameObject param)
    {

        
        Debug.Log("I'm calling the block");
            
        if (flowchart != null)
        {
            
            flowchart.ExecuteBlock("CallBlock");
            
            //interacted = true;
        }
        


    }

    // Start is called before the first frame update
    void Awake()
    {
        
        
        flowchart = GetComponent<Flowchart>();
        playerMoveSpeed = playerMovement.MoveSpeed;
        playerRotationSpeed = playerMovement.RotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDayFlowchart.GetBooleanVariable("BlockExecuting"))
        {
            playerMovement.MoveSpeed = 0;
            playerMovement.RotationSpeed = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            playerMovement.MoveSpeed = playerMoveSpeed;
            playerMovement.RotationSpeed = playerRotationSpeed;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
