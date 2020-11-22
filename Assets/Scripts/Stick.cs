using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour, ICatchable
{
    [SerializeField]
    private Vector2 releaseVelocity;

    [SerializeField]
    private float rotationForce;


    private Rigidbody2D rb;

    public FetchingObjective fetchObj;
  

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Catch()
    {
        rb.isKinematic = true;
    }

    public void Release(Vector2 parentVelocity)
    {

        //Debug.Log(GameManager.Instance.Player.faceDir);
        rb.isKinematic = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.AddForce(parentVelocity + new Vector2(releaseVelocity.x *  GameManager.Instance.Player.faceDir, releaseVelocity.y), ForceMode2D.Impulse);
        rb.AddTorque(rotationForce * GameManager.Instance.Player.faceDir * rb.velocity.magnitude, ForceMode2D.Impulse);
       // Physics2D.Simulate(Time.deltaTime);
        //Debug.Log(parentVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.gameObject.layer = LayerMask.NameToLayer("IgnorePlayer");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Owner"))
        {
            CatchHandler ch = GameManager.Instance.Player.GetComponent<CatchHandler>();
            if (ch.CatchSlot.childCount == 0)
            {
                fetchObj?.StickReachedGoal();
            }
        }
    }
}
