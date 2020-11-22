using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchingObjective : Objective
{
    [SerializeField]
    private float timeLimit = 3f;
    [SerializeField]
    private Stick stickPrefab;

    private float objectiveTimeLeft;

    private Stick stick;

    public void StickReachedGoal()
    {
        base.ObjectiveCompleted();
        Destroy(this.gameObject);
        Destroy(stick.gameObject);
    }

    public override void StartObjective(Task task = null)
    {
        base.StartObjective(task);
        objectiveTimeLeft = timeLimit;
        stick = Instantiate(stickPrefab, GameManager.Instance.Owner.throwFrom.position, Quaternion.identity);
        stick.fetchObj = this;
        Rigidbody2D rb = stick.GetComponent<Rigidbody2D>();
        float x = Random.Range(-16f, -6f);
        float y = Random.Range(7, 12);
        Vector2 vel = new Vector2(x, y);
        rb.AddForce(vel, ForceMode2D.Impulse);
        rb.AddTorque(0.05f * vel.magnitude, ForceMode2D.Impulse);
    }



    private void Update()
    {
       

        if (timeLimit > 0f)
        {
            objectiveTimeLeft -= Time.deltaTime;
            if (objectiveTimeLeft <= 0f)
            {
                base.ObjectiveFailed();
                Destroy(this.gameObject);
                Destroy(stick.gameObject);
            }
        }
    }
}
