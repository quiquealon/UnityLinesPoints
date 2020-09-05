using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LineScript : MonoBehaviour
{
   
    private LineRenderer line;
    private Vector3 mousePos;
    public Material material;
    private int currLines = 0;
    public int numberLines;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            randomLines(numberLines);
        }

        if (Input.GetKeyDown("w"))
        {
            destroyLines();
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (line == null)
            {
                createLine();
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            line.SetPosition(0, mousePos);
            line.SetPosition(1, mousePos);
        }

        else if (Input.GetMouseButtonUp(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(1, mousePos);
            line = null;
            currLines++;
        }

        else if (Input.GetMouseButton(0) && line)
        {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            line.SetPosition(1, mousePos);

        }
    }
    

    void createLine()
    {   
        
        line = new GameObject("Line" + currLines).AddComponent<LineRenderer>();
        line.tag = "linea";
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        line.endColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        line.positionCount = 2;
        line.startWidth = 8.0f;
        line.endWidth = 8.0f;
        line.useWorldSpace = true;



    }


    void destroyLines()
    {
        GameObject[] allPoints = GameObject.FindGameObjectsWithTag("linea");

        foreach (GameObject p in allPoints)
        {
            Destroy(p);
        }
    }


    void randomLines(int num)
    {
        for (int i=0;i<num;i++)
        {   
            Vector3 randomCenter= new Vector3(Random.Range(-900.0F, 900.0F), Random.Range(-500.0F, 500.0F), 0);
            

            Vector3 position1 =  new Vector3(Random.Range(-35.0F, 35.0F), Random.Range(-35.0F, 35.0F), 0);
            Vector3 position2 =  new Vector3(Random.Range(-35.0F, 35.0F), Random.Range(-35.0F, 35.0F), 0);

            createLine();

            line.SetPosition(0, randomCenter + position1);
            line.SetPosition(1, randomCenter + position2);
            
            currLines++;
        }
       
    }
}
