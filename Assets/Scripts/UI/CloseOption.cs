using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseOption : MonoBehaviour
{
    [SerializeField] GameObject optionTab;
    [SerializeField] private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        optionTab.SetActive(false);
    }
}
