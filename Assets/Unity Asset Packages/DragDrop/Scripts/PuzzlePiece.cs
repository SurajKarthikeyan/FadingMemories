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
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    //private enum Rotation { 
    //    Zero = 0, Ninety = 90, OneEighty = 180, TwoSeventy = 270
    //}


    [SerializeField] private Canvas canvas;

    PuzzleSystem puzzleSystem;

    UnityEngine.UI.Outline outline;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public int angle = 0;
    
    private List<int> orientations;

    public int id = -1;


    private void Start() {
        puzzleSystem = canvas.GetComponent<PuzzleSystem>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        outline = GetComponent<UnityEngine.UI.Outline>();

        orientations = puzzleSystem.orientations;

        int angleIndex = Random.Range(0, orientations.Count);

        angle = orientations[angleIndex];

        rectTransform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, angle);

    }

    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        //Debug.Log("OnPointerDown");
        if (puzzleSystem.previouslySelectedPiece != null)
        {
            puzzleSystem.previouslySelectedPiece = puzzleSystem.currentlySelectedPiece;
        }
        else
        {
            puzzleSystem.previouslySelectedPiece = this;
        }
        
        puzzleSystem.currentlySelectedPiece = this;

        //Set the outline of the previously selected piece to be off
        puzzleSystem.previouslySelectedPiece.outline.enabled = false;
        //Set the outline of the currently selected piece to be on
        puzzleSystem.currentlySelectedPiece.outline.enabled = true;
    }

}
