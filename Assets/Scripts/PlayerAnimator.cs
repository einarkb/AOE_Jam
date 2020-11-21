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

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 0f)
        {
            objectToFlip.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (rb.velocity.x < 0f)
        {
            objectToFlip.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
