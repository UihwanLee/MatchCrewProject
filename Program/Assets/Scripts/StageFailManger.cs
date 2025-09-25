using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFailManger : MonoBehaviour
{
    public static StageFailManger instance;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StageFail()
    {
        canvas.gameObject.SetActive(true);
    }
}
