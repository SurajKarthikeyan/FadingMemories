/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {

    public bool filled = false;
    [Tooltip("DO NOT FILL THIS IN")]
    public PuzzlePiece puzzlePiece = null;
    public int id = -1;
    public AudioSource myPuzzleAudioSource;
    public AudioClip[] myPuzzleAudioClips;


    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
            myPuzzleAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myPuzzleAudioSource.PlayOneShot(myPuzzleAudioClips[Random.Range(0, 2)]);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            filled = true;
            puzzlePiece = eventData.pointerDrag.GetComponent<PuzzlePiece>();

            
        }
        else
        {
            filled = false;
            puzzlePiece = null;
        }
    }

    public bool CompareIDs()
    {
        if (puzzlePiece != null)
        {
            if (puzzlePiece.id == id)
            {
                return true;
            }
            
        }
        return false;
    }

    public bool CheckRotation()
    {
        return puzzlePiece.angle == 0;
    }

}
