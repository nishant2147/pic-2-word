using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevel : MonoBehaviour
{
    public GameObject Mainscreen,Playerscreen;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Playbutton()
    {
        Mainscreen.SetActive(false);
        Playerscreen.SetActive(true);
    }
}
