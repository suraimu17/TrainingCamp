using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameFlow;

public class ClearTime : MonoBehaviour
{
    [SerializeField] private ElapsedTime elapsedTime;
    [SerializeField] private GameSceneDirector gameSceneDirector;
    private TextMeshProUGUI testMesh;

    // Start is called before the first frame update
    void Start()
    {
        testMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSceneDirector.IsGoal)
        {
            int min = (int)(elapsedTime.time / 60);
            testMesh.text = min + " : " + (elapsedTime.time - min * 60).ToString("00");
        }
    }
}
