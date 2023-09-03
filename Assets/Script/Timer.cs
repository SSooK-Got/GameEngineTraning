using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject Target;
    private Text timerText;
    public float time;
    public int currentTime;
    
    void Start()
    {
        timerText = GetComponent<Text>();
    }
    void Update()
    {
        if (Target.activeSelf)
        {
            currentTime = 300 - (int)time;
            timerText.text = "Timer :" + currentTime;
        }

    }
    private void FixedUpdate()
    {
        if (Target.activeSelf)
            time += Time.deltaTime;
    }



}
