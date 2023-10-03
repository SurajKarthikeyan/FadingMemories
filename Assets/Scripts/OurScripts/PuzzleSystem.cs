using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PuzzleSystem : MonoBehaviour
{
    public GameObject winText;
    public readonly List<int> orientations = new List<int>();
    public List<ItemSlot> puzzleSlots = new List<ItemSlot>();

    public PuzzlePiece currentlySelectedPiece = null;
    public PuzzlePiece previouslySelectedPiece = null;

    public AudioSource audioSource;
    public AudioClip victory;
    private bool victoryPlayed = false;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            orientations.Add(i * 90);
        }

    }

    // Update is called once per frame
    void Update()
    {
        ValidatePuzzle();
    }

    public void ValidatePuzzle()
    {
        bool puzzleComplete = true;
        for (int i = 0; i < puzzleSlots.Count; i++)
        {
            if (! (puzzleSlots[i].CompareIDs() && puzzleSlots[i].CheckRotation())) 
            {
                puzzleComplete = false;
                break;
            }
        }

        if (puzzleComplete)
        {
            winText.SetActive(true);
            if(!victoryPlayed)
            {
                audioSource.PlayOneShot(victory);
                victoryPlayed = true;
            }
        }
    }

    public void RotateLeft()
    {
        if (currentlySelectedPiece != null)
        {
            //Debug.Log("rotate left");
            currentlySelectedPiece.GetComponent<RectTransform>().eulerAngles += new Vector3(0, 0, 90);
            currentlySelectedPiece.angle += 90;
            if (currentlySelectedPiece.angle == 360)
            {
                currentlySelectedPiece.angle = 0;
            }
        }
        
        
    }

    public void RotateRight()
    {
        if (currentlySelectedPiece != null)
        {
            //Debug.Log("rotate right");
            currentlySelectedPiece.GetComponent<RectTransform>().eulerAngles -= new Vector3(0, 0, 90);
            currentlySelectedPiece.angle -= 90;
            if (currentlySelectedPiece.angle == 360)
            {
                currentlySelectedPiece.angle = 0;
            }
        }
        
    }
}
