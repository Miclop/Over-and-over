using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public GameObject Text;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text = GameObject.FindGameObjectWithTag("TEXT");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Text.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Text.SetActive(false);
    }
}
