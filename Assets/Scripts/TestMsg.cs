using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMsg : MonoBehaviour
{
    private ChatBubbleManager c;
    int i = 0;
    void Start()
    {
        c = GameManager.Instance.ChatBubbleManager;
        InvokeRepeating("Test", 1f, 3f);
    }

    public void Test()
    {
        i++;
        c.OwnerSpeaking.ShowMessage("Hei, test" + i.ToString(), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
