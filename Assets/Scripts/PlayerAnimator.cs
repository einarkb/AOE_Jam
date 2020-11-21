using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    public Animator Anim
    {
        get => anim;
        private set => anim = value;
    }

  
    private Player player;
    private Rigidbody2D rb;
    [SerializeField]
    private Transform objectToFlip;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }



    private void OnEnable()
    {
        EventManager.Instance.playerFacingDirectionChanged += (val) => FlipGraphics(val);
    }

    private void OnDisable()
    {
        EventManager.Instance.playerFacingDirectionChanged -= (val) => FlipGraphics(val);
    }

    private void FlipGraphics(float dir)
    {
        float y = Mathf.Clamp01(dir);
        objectToFlip.transform.rotation = Quaternion.Euler(0f, y * 180f, 0f);
    }
}
