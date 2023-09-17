using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject overTab;
    [SerializeField] private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        overTab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.hp <= 0)
        {
            overTab.SetActive(true);
        }
    }
}
