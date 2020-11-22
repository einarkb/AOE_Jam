using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    [SerializeField]
    private float fadeTime = 0.3f;

    [SerializeField]
    private Transform attachedTo;

    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    public TMPro.TextMeshProUGUI Text
    {
        get => text;
        private set => text = value;
    }

    private UnityEngine.UI.Image image;

    private Camera cam;

    private float durationLeft = 0f;
    private float duration = 0f;



    private void OnEnable()
    {
        cam = GameManager.Instance.Cam;
        image = GetComponent<UnityEngine.UI.Image>();
        image.color = new Color(image.color.r, image.color.b, image.color.g, 0f);
        this.text.alpha = 0f;

    }


    private void FixedUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = cam.WorldToScreenPoint(attachedTo.position);
        transform.rotation = attachedTo.rotation;
        Text.transform.rotation = Quaternion.identity;
    }

    public void ShowMessage(string text, float duration, float delay = 0f)
    {
        GameManager.Instance.StartCoroutine(MSG(text, duration, delay));
    }

    private IEnumerator MSG(string text, float duration, float delay)
    {
        yield return new WaitForSeconds(delay);
        this.text.text = text;
        this.duration = duration;
        durationLeft = duration;
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }

        UpdatePosition();
    }

    private void Update()
    {
      
        if (gameObject.activeInHierarchy)
        {
            durationLeft -= Time.deltaTime;
            if (durationLeft <= 0f)
            {
                gameObject.SetActive(false);
            }
            else if (durationLeft < fadeTime && fadeTime != 0f)
            {
                float t = durationLeft / fadeTime;
                float a = Mathf.Lerp(0f, 1f, t);
                image.color = new Color(image.color.r, image.color.b, image.color.g, a);
                text.alpha = a;
            }
            else if (durationLeft >= duration - fadeTime && fadeTime != 0f)
            {
                float t = (duration - durationLeft) / fadeTime;
                float a = Mathf.Lerp(0f, 1f, t);
                image.color = new Color(image.color.r, image.color.b, image.color.g, a);
                text.alpha = a;
      
            }
            

        }
    
    }


}
