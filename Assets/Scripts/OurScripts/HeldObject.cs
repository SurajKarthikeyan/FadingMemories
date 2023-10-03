using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeldObject : MonoBehaviour, IInteractable
{
    public GameObject hand;

    public GameObject dropOff;

    private bool pickedUp;

    public AudioSource myAudioSource;
    public AudioClip pickupItemSFX;

    public void Interact(GameObject param)
    {
        if (!pickedUp)
        {
            transform.position = hand.transform.position;
            transform.parent = hand.transform;
            pickedUp = true;
            myAudioSource.PlayOneShot(pickupItemSFX);
        }
        else
        {
            transform.position = dropOff.transform.position;
            transform.parent = null;
        }
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            transform.position = hand.transform.position;
            
        }
    }

    public void DropOffItems(GameObject param)
    {
        foreach(Transform child in param.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
