using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearCtrl : MonoBehaviour
{
    [SerializeField] GameObject view;
    [SerializeField] LevelCtrl1 levelCtrl;
    [SerializeField] PathCtrl1 pathCtrl;
    [SerializeField] DragLineCtrl1 dragLineCtrl;
    public void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(index + 1);
    }

    public void Next_Level()
    {
        this.view.SetActive(false);
        Destroy(this.levelCtrl.dots.gameObject);
        this.levelCtrl.level++;
        PlayerPrefs.SetInt("Level", this.levelCtrl.level);
        this.levelCtrl.SetUp();
        this.pathCtrl.SetUpLinePos();
        this.dragLineCtrl.SetUp();
    }
}
