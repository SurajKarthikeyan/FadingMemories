using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;


public class HighlightableObject : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private Camera _mainCam;
    [SerializeField] private float interactRayDistance;
    [SerializeField] private LayerMask layer;
    private List<GameObject> prevList;
    public StarterAssets1 playerInteract;
    private InputAction interact;
    public GameObject currGO;

    #region EnableDisable
    private void OnEnable()
    {
        playerInteract.Enable();
        interact = playerInteract.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }

    private void OnDisable()
    {
        playerInteract.Disable();
        interact.Disable();
    }
    #endregion

    #region Monobehavior
    private void Awake()
    {
        prevList = new List<GameObject>(); 
        playerInteract = new StarterAssets1(); 
    }
    private void Update()
    {
        RaycastHit[] listCast = Physics.RaycastAll(_mainCam.transform.position, _mainCam.transform.forward, 
            interactRayDistance, layer).OrderBy(h => h.distance).ToArray();

        if (listCast.Length != 0)
        {
            for(int i = 0; i< listCast.Length; i ++) 
            {
                currGO = listCast[i].collider.gameObject;
                if (currGO.GetComponent<Outline>() != null) 
                {
                    currGO.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
                    prevList.Add(currGO);
                    break;
                }
                
            }
            

        }
        else
        {
            currGO = null;
            for (int i = 0; i < prevList.Count; i++)
            {
                GameObject go = prevList[i];
                go.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
            }
            prevList.Clear();
        }
    }
    #endregion

    #region InterfaceImplementaion
    public void Interact(InputAction.CallbackContext context)
    {
        
        if (currGO != null && currGO.GetComponent<IInteractable>() != null)
        {
            currGO.GetComponent<IInteractable>().Interact(currGO);
        }
        else
        {
            Debug.Log("Null");
        }
        
    }
    #endregion

}
