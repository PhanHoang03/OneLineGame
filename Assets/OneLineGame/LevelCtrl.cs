using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCtrl : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _text;
    public int level;

    private void Start()
    {
        //this.SetUp();
    }

    private void SetUp()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        Transform source = transform.parent;
        this._text.text = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("Level", index);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadSceneAsync(1);
    }

    public void Continue()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
