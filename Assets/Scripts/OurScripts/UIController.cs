using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class UIController : MonoBehaviour
{

    public GameObject blackOutSquare;
    private Flowchart flowchart;
    // Start is called before the first frame update
    private void Awake()
    {
        flowchart = GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    StartCoroutine(FadeBlackOutSquare());
        //}

        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    StartCoroutine(FadeBlackOutSquare(false));
        //}
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        
    }

    public void RoomSelect()
    {
        StartCoroutine(FadeBlackOutSquare());
        flowchart.ExecuteBlock("SelectionBlock");
    }
    public void RoomSelected()
    {
        StartCoroutine(FadeBlackOutSquare(false));
        
    }
}
