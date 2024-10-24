using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICtrl1 : MonoBehaviour
{
    [SerializeField] protected GameObject gameClear;
    [SerializeField] protected LevelCtrl1 levelCtrl;

    private void Start()
    {
        //this.SetUp();
    }

    private void SetUp()
    {
        Transform source = transform.Find("GameClearCtrl");
        
        source = source.Find("View");
        /*GameObject reward = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Reward"));
        reward.transform.parent = source;
        reward.transform.localPosition = new Vector3 (-0.06f, 0.12f, -0.1064964f);*/

        source = source.Find("NextLevel");

        source.GetComponent<Button>().onClick.AddListener(delegate() {gameClear.GetComponent<GameClearCtrl>().Next_Level();});

        /*source.GetComponent<Image>().sprite = Resources.Load<Sprite>("win_lose/btn");
        source.GetComponent<Image>().SetNativeSize();
        source.localScale = new Vector3 (0.007f, 0.007f, 1f);
        source.localPosition = new Vector3 (-0.09f, -1.47f, -0.1064964f);*/

        // -0.06 0.12 -0.1064964 0.005 0.005

        source = source.parent;
        
        source = source.Find("GameClearUI");
        //source.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("win_lose/popup");

        source = source.Find("Window_150");
        //source.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("win_lose/win");

        source = transform.Find("LevelHolder");
        //source.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("win_lose/popup");
        source.localScale = new Vector3 (0.2f, 0.2f, 1f);

        source = source.Find("Text (TMP)");
        source.GetComponent<RectTransform>().localScale = new Vector3 (0.05f, 0.05f, 1f);

        int index = SceneManager.GetActiveScene().buildIndex;

        if (index == 0) return;

        GameObject backButton = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/BackButton"));

        backButton.transform.parent = transform;
        backButton.transform.localPosition = new Vector3(-0.13f, 4.2f, 0f);
        backButton.GetComponent<Button>().onClick.AddListener(delegate() {this.Home();});
    }

    public void GameClearUI()
    {
        this.gameClear.transform.Find("View").gameObject.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
