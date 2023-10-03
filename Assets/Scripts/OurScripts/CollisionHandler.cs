using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CollisionHandler : MonoBehaviour
{
    SceneEventHandler eventHandler;

    public UIController uiController;

    private Flowchart flowchart;

    // Start is called before the first frame update
    void Start()
    {
        eventHandler = GetComponent<SceneEventHandler>();
        flowchart = GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dialogue")
        {
            flowchart.ExecuteBlock("CallBlock");
        }
        else if (other.gameObject.tag == "RoomSwitch")
        {
            uiController.RoomSelect();
        }
    }

    public void TeleportPlayer(GameObject destination)
    {
        gameObject.SetActive(false);
        transform.position = destination.transform.position;
        transform.rotation = destination.transform.rotation;
        gameObject.SetActive(true);
    }
}
