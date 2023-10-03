using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;

public class ActualTaskListManager : MonoBehaviour
{
    public Flowchart flowChart;
    public TMP_Text task1TMP;
    public TMP_Text task2TMP;
    public TMP_Text task3TMP;

    public AudioSource myAudioSource;
    public AudioClip taskCompleteSFX;

    private bool task1sfx = false, task2sfx = false, task3sfx = false;

    const string STRIKE_START = "<s>";
    const string STRIKE_END = "</s>";

    private void Update()
    {
        if (flowChart != null) 
        {
            if (flowChart.GetBooleanVariable("Scene5Complete")) 
            {
                if(!task1sfx)
                {
                    myAudioSource.PlayOneShot(taskCompleteSFX);
                    task1sfx = true;
                }
                task1TMP.text = STRIKE_START + task1TMP.text + STRIKE_END;
            }

            if (flowChart.GetBooleanVariable("Scene7Complete")) 
            {
                if (!task2sfx)
                {
                    myAudioSource.PlayOneShot(taskCompleteSFX);
                    task2sfx = true;
                }
                task2TMP.text = STRIKE_START + task2TMP.text + STRIKE_END;
            }

            if (flowChart.GetBooleanVariable("Scene10Complete"))
            {
                if (!task3sfx)
                {
                    myAudioSource.PlayOneShot(taskCompleteSFX);
                    task3sfx = true;
                }
                task3TMP.text = STRIKE_START + task3TMP.text + STRIKE_END; 
            }
        }
    }
}
