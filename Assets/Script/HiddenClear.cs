using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenClear : MonoBehaviour
{
    public PlayerController player;
    public Timer cTime;
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target.activeSelf)
            if (player.wallet > 10 && cTime.time < 100)
                SceneManager.LoadScene("HiddenEnding");
            else
                SceneManager.LoadScene("GameWin");
    }
}
