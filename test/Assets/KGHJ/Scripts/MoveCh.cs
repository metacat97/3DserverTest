using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("w �������ֿ���");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("s �������ֿ���");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("d �������ֿ���");
        }
    }
}
