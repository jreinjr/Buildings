using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Resource;

public class Test : MonoBehaviour
{
    public ResourceBundle rb = new ResourceBundle
    {
        { Gold, 100 },
        { Culture, 100 },
        { Wool, 100 }
    };

    // Start is called before the first frame update
    void Start()
    {
        var test = rb + new ResourceBundle { { Gold, 100 } };
        test *= 2;
        test -= new ResourceBundle { { Culture, 100 } };
        test -= new ResourceBundle { { Resource.Cloth, 100 }, { Stone, 100 } };
        Debug.Log(test.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
