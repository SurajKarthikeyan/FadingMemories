using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube1 : MonoBehaviour, IInteractable
{

    public GameObject player;
    public void Interact(GameObject param)
    {
        TaskManager taskM = player.GetComponent<TaskManager>();
        taskM.GlobalTaskInteract(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
