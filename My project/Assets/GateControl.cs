using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Light;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MazeInfo.NumofRunes == 0)
        {
            Light.SetActive(true);
            Destroy(this.gameObject);
            Debug.Log("unlock");
        }
    }
}
