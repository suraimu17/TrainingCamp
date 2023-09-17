using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameFlow;

public class ElapsedTime : MonoBehaviour
{
    [SerializeField] private GameSceneDirector gameSceneDirector;
    private TextMeshProUGUI textMesh;
    public float time { get; private set; } = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameSceneDirector.IsGoal)
        {
            time += Time.deltaTime;
        }

        int min = (int)(time / 60);
        textMesh.text = min + " : " + (time - min * 60).ToString("00");
    }
}
