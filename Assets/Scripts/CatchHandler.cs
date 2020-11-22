using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchHandler : MonoBehaviour
{
    [SerializeField]
    private Transform catchSlot;
    public Transform CatchSlot
    {
        get => catchSlot;
        private set => catchSlot = value;
    }
    
    [SerializeField] 
    Collider2D interactionCollider;

    [SerializeField]
    private float cooldownTime = 0.2f;

    private ContactFilter2D contactFilter;

    private ICatchable currentCatch;
    private Transform currentCatchTransform;
    private Rigidbody2D rb;

    private Collider2D[] hitResults;

    private bool cooldown = false;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        contactFilter.layerMask = (1 << LayerMask.NameToLayer("Prop")) | (1 << LayerMask.NameToLayer("IgnorePlayer"));
        contactFilter.useLayerMask = true;
        contactFilter.useTriggers = true;

        hitResults = new Collider2D[6];
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(TryCatchOrReleaseItem());
        }
    }

    public bool TryCatchOrReleaseItem()
    {
        if (cooldown == true)
        {
            return false;
        }

        if (currentCatch != null)
        {
            currentCatch.Release(rb.velocity);
            currentCatchTransform.parent = null;
            currentCatch = null;

            StartCoroutine(StartCooldown());
            return true;
        }
        else
        {
            int hits = interactionCollider.OverlapCollider(contactFilter, hitResults);
            Collider2D bestHit = null;
            float smallestDistance = 100f;

            for (int i = 0; i < hits; i++)
            {
                ICatchable item = hitResults[i].GetComponent<ICatchable>();
                if (item == null)
                {
                    continue;
                }

                float distance = (catchSlot.transform.position - hitResults[i].transform.position).magnitude;

                if (bestHit == null || distance < smallestDistance)
                {
                    bestHit = hitResults[i];
                    smallestDistance = distance;
                }
            }

            if (bestHit != null)
            {
                ICatchable item = bestHit.GetComponent<ICatchable>();
                item.Catch();
                currentCatch = item;
                currentCatchTransform = bestHit.transform;
                bestHit.transform.parent = catchSlot;
                bestHit.transform.localPosition = Vector3.zero;
                bestHit.transform.localRotation = Quaternion.Euler(Vector3.zero);

                StartCoroutine(StartCooldown());
                return true;
            }
            return false;
        }

    }

    private IEnumerator StartCooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        cooldown = false;
    }

}
