using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public GameObject Target;

    private void Start()
    {
        
        Target.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Blocking();
    }

    void Blocking()
    {
        if (PlayerController.isBlocking == true)
            Target.gameObject.SetActive(true);
        else if (PlayerController.isBlocking == false)           
            Target.gameObject.SetActive(false);
    }
}
