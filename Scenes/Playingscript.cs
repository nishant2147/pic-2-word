using System;
using UnityEngine;
using UnityEngine.UI;

public class Playingscript : MonoBehaviour
{
    public Button[] optionbuttons;
    public GameObject buttonPrefab;
    public GameObject ansparent;
    string optionText;
    string Answertext;
    string[] allAnswer = { "CAT", "GIRL", "BAG", "FIRE", "ORANGE", "EGG", "LAKE", "STARS", "STATUE" , "WATERMELON" , "BRIGE" , "SMOKE"};
    Button[] answerButton;
    public Image Imagepicture;
    public Sprite[] allPicture;
    public GameObject finalpage;
    int currentlevel;
    string alphabhat = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void reshuffle(char[] alphabhat)
    {
        for (int i = 0; i < alphabhat.Length; i++)
        {
            char w = alphabhat[i];
            int r = UnityEngine.Random.Range(i, alphabhat.Length);
            alphabhat[i] = alphabhat[r];
            alphabhat[r] = w;
        }
    }

    public void OnEnable()
    {
        currentlevel = PlayerPrefs.GetInt("level");
        Imagepicture.sprite = allPicture[currentlevel];
        Answertext = allAnswer[currentlevel];

        optionText = Answertext;

        for (int i = Answertext.Length; i < optionbuttons.Length; i++)
        {
            optionText += alphabhat[UnityEngine.Random.Range(0, alphabhat.Length)];
        }

        char[] otArray = optionText.ToCharArray();
        reshuffle(otArray);

        for (int i = 0; i < optionbuttons.Length; i++)
        {
            Button button = optionbuttons[i];
            Text text = button.GetComponentInChildren<Text>();
            text.text = "" + otArray[i];
            int k = i;

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {

                for (i = 0; i < answerButton.Length; i++)
                {
                    string a = answerButton[i].GetComponentInChildren<Text>().text;
                    if (a == "")
                    {
                        //bIndex0 ---> k
                        PlayerPrefs.SetInt("bIndex" + i, k);
                        answerButton[i].GetComponentInChildren<Text>().text = text.text;
                        text.text = "";
                        break;
                    }

                }

                Winner();

            });
        }

        for (int i = 0; i < Answertext.Length; i++)
        {
            Instantiate(buttonPrefab, ansparent.transform);
        }

        answerButton = ansparent.GetComponentsInChildren<Button>();
        print(answerButton.Length);


        for (int i = 0; i < answerButton.Length; i++)
        {
            Button button = answerButton[i];
            Text text = button.GetComponentInChildren<Text>();
            text.text = "";

            int k = i;

            button.onClick.AddListener(() =>
            {
                if (text.text != "")
                {
                    int bIndex = PlayerPrefs.GetInt("bIndex" + k);
                    print(bIndex);

                    optionbuttons[bIndex].GetComponentInChildren<Text>().text = text.text;
                    text.text = "";

                    //PlayerPrefs.DeleteKey("bIndex" + k);

                }
            });

        }
    }
    private void Winner()
    {

        int count = 0;
        for (int i = 0; i < answerButton.Length; i++)
        {
            if (answerButton[i].GetComponentInChildren<Text>().text == Answertext[i].ToString())
            {
                count++;
            }

            if (count == answerButton.Length)
            {
                print("WIN--->");
                clearAll();
                PlayerPrefs.SetInt("level", currentlevel + 1);
                OnEnable();
            }
        }
    }
    private void clearAll()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            answerButton[i].transform.parent = null;
            Destroy(answerButton[i].gameObject);
        }
    }
}