using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControll : MonoBehaviour
{
    private Animator fade;




    void Start()
    {
        fade = GetComponent<Animator>();
    }

    public void FadeIN()
    {

        fade.SetBool("Fade", false);



    }

    public void FadeOUT()
    {
        fade.SetBool("Fade", true);

    }
        


}
