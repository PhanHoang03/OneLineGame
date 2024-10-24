using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PathCtrl1 : MonoBehaviour
{
    private List<LineRenderer> lineRenderer = new List<LineRenderer>();
    [SerializeField] protected GameObject arrowPrefab;
    [SerializeField] protected List<GameObject> dots = new List<GameObject>();
    [SerializeField] protected LevelSO levelSO;
    [SerializeField] protected LineRenderer linePreset;
    [SerializeField] protected LevelCtrl1 levelCtrl;
    protected int numPath;
    public int NumPath => numPath;

    private void Start()
    {
        this.SetUpLinePos();
    }

    public virtual void SetUpLinePos()
    {
        this.arrowPrefab = Resources.Load<GameObject>("Prefabs/Triangle");
        //Debug.Log(this.arrowPrefab.name);
        this.numPath = 0;
        //Debug.Log("Level_" + this.levelCtrl.level.ToString());
        this.levelSO = this.levelSO = Resources.Load<LevelSO>("Level_" + this.levelCtrl.level.ToString());
        //Debug.Log(this.levelSO.name);
        //this.levelSO = Resources.Load<LevelSO>("Level_1");

        this.dots.Clear();
        foreach (Transform dot in this.levelCtrl.dots) 
        {
            this.dots.Add(dot.gameObject); 
        }
        
        for (int i = 0; i < levelSO.numRow; i++) 
        {
            for (int j = i + 1; j < levelSO.numCol; j++)
            {
                if (levelSO.board[i]._row[j] == false && levelSO.board[j]._row[i] == false) continue;
                //Debug.Log("The 2 points are");
                //Debug.Log(i.ToString() + " and " + j.ToString());
                this.numPath++;
                //Debug.Log(this.lineRenderer.Count.ToString() + " and " + this.numPath.ToString());
                LineRenderer lr;
                if (this.lineRenderer.Count < this.numPath) 
                {
                    lr = Instantiate(linePreset);
                    this.lineRenderer.Add(lr);
                }
                else 
                {
                    lr = this.lineRenderer[this.numPath - 1];
                }
                lr.gameObject.SetActive(true);
                lr.transform.parent = transform;    
                int index = this.numPath - 1;
                this.lineRenderer[index].positionCount = 2;
                this.lineRenderer[index].SetPosition(0, dots[i].transform.position);
                this.lineRenderer[index].SetPosition(1, dots[j].transform.position);

                if (levelSO.board[i]._row[j] == true && levelSO.board[j]._row[i] == true) continue;

                Vector3 startPos = dots[i].transform.position;
                Vector3 endPos = dots[j].transform.position;
                
                if (levelSO.board[i]._row[j] == false) (startPos, endPos) = (endPos, startPos);

                // Calculate the midpoint
                Vector3 midpoint = (startPos + endPos) / 2;

                // Instantiate the arrow prefab at the midpoint
                GameObject arrow = Instantiate(arrowPrefab, midpoint, Quaternion.identity);
                arrow.transform.parent = transform;

                // Rotate the arrow to align with the line direction
                Vector3 direction = (endPos - startPos).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                arrow.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
        }

        for (int i = this.numPath; i < this.lineRenderer.Count; i++)
        {
            this.lineRenderer[i].gameObject.SetActive(false);
        }
    }
}
