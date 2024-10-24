using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCtrl1 : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _text;
    public int level;
    public Transform dots;

    private void Awake()
    {
        this.SetUp();
    }

    public void SetUp()
    {
        this.level = PlayerPrefs.GetInt("Level");
        if (this.level < 1) this.level = 1;
        this.dots = Instantiate<Transform>(Resources.Load<Transform>("Prefabs/DotLayout/" + this.level.ToString()));
        //int index = SceneManager.GetActiveScene().buildIndex;
        Transform source = transform.parent;
        this._text.text = "Level " + this.level.ToString();
        //PlayerPrefs.SetInt("Level", this.level);
        //Debug.Log("The level is:");
        //Debug.Log(this.level);
    }
}
