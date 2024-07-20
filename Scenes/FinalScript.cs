
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    public GameObject finalPage, playerPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Nextbutton()
    {
        finalPage.SetActive(false);
        playerPage.SetActive(true);
    }
}
