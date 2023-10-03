using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    private Animator doorAnimator;

    //public Animation doorOpenAnimation;
    //public Animation doorCloseAnimation;
    private bool doorOpen;

    public AudioSource doorAudio;
    public AudioClip doorOpenSFX;
    public AudioClip doorCloseSFX;

    // Start is called before the first frame update
    void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject param)
    {
        Debug.Log("I'm a door");
        if (!doorOpen)
        {
            doorAnimator.Play("BaseLayer.DoorClosed");
            doorOpen = true;
            doorAudio.PlayOneShot(doorOpenSFX);
        }
        else
        {
            doorAnimator.Play("BaseLayer.DoorOpened");
            doorOpen =false;
            doorAudio.PlayOneShot(doorCloseSFX);
        }

    }

}
