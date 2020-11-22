using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubble : MonoBehaviour
{
    [SerializeField]
    private Transform attachedTo;

    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    public TMPro.TextMeshProUGUI Text
    {
        get => text;
        private set => text = value;
    }

    private Camera cam;


    void Start()
    {
        cam = GameManager.Instance.Cam;   
    }

    private void FixedUpdate()
    {
        transform.position = cam.WorldToScreenPoint(attachedTo.position);
        transform.rotation = attachedTo.rotation;
        Text.transform.rotation = Quaternion.identity;
    }


}
