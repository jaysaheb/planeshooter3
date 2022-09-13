using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class coincount : MonoBehaviour
{
    public Text coincountText;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coincountText.text = count.ToString();
    }
    public void AddCount()
    {
        count++;
    }
}
