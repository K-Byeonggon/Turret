using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoView : MonoBehaviour
{
    private Color color = Color.red;
    private float radius = 0.2f;


    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }

}
