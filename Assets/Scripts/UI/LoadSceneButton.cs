using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] string stageName;
    [SerializeField] AudioType type;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SoundManager.Instance.PlaySE(type);
        Invoke("Load", 0.8f);
    }

    private void Load()
    {
        SceneManager.LoadScene(stageName);
    }
}
