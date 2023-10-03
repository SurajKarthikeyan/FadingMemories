using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class PuzzleLoad : MonoBehaviour, IInteractable
{

    public Flowchart currentDayFlowChart;
    public void Interact(GameObject param)
    {
        //Debug.Log("Load Puzzle");
        SceneManager.LoadScene("ZaneScene2");
    }

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        mesh.UploadMeshData(false);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (currentDayFlowChart.GetBooleanVariable("FinalSceneComplete"))
    //    //{
    //    //    gameObject.SetActive(true);
    //    //}
    //}
}
