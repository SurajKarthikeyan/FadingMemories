using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    // Use t$$anonymous$$s for initialization
    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.visible = true;
    }
}


