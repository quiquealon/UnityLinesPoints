using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScrip : MonoBehaviour
{

    [SerializeField]
    private GameObject linePointPrefab;

    public int numberPoints;
    private int currPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            
            randomPoints(numberPoints);

        }

        if (Input.GetKeyDown("s"))
        {
            ClearAllPoints();
        }
    }

    private void CreatePointMarker(Vector3 pointPosition)
    {   
       Instantiate(linePointPrefab, pointPosition, Quaternion.identity);       
    }

    private void ClearAllPoints()
    {
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("PointMarker");

        foreach (GameObject p in allPoints)
        {
            Destroy(p);
        }
      

    }

    private void randomPoints(int num)
    {
        for(int i = 0; i < num; i++)
        {
            Vector3 newPos = new Vector3(Random.Range(-940.0F, 940.0F), Random.Range(-520.0F, 520.0F), 0);
            CreatePointMarker(newPos);
            currPoints++;
        }
    }
}
