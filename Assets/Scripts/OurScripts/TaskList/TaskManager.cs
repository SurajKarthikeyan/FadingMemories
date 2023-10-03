using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public bool alphaIsComplete;
    public List<GameObject> task1;
    public List<GameObject> task2;
    public List<GameObject> task3;
    public List<List<GameObject>> alphaTasks;

    #region Monobehavior
    private void Awake()
    {
        alphaTasks = new List<List<GameObject>>
        {
            task1,
            task2,
            task3,
        };
    }

    private void Update()
    {
        if (alphaIsComplete) 
        {
            Debug.Log("Alpha Task is Done!");
            //at this point, edit the actual image/ sprite of the task list thingi
            // For now, deal with a debug
        }

        if(alphaTasks.Count == 0) 
        {
            alphaIsComplete = true;     // If there are no more tasks, its complete
        }


    }
    #endregion


    #region Private Methods
    public void GlobalTaskInteract(GameObject currGO) 
    {
        List<GameObject> currentTask = alphaTasks[0];
        for(int i = 0; i< currentTask.Count; i++) 
        {
            if (currentTask[i] == currGO) 
            {
                alphaTasks.RemoveAt(0);
            }
        }
    }
    #endregion
}
