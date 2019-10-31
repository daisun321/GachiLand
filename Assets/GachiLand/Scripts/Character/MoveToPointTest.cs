using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveToPoint))]
public class MoveToPointTest : MonoBehaviour
{
    private MoveToPoint moveToPoint;

    private void Awake()
    {
        moveToPoint = GetComponent<MoveToPoint>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray);
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    moveToPoint.SetTarget(hit.point);
                    break;
                }
            }
        }
    }
}
