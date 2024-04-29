using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotSpeed = 150f;

    void Update()
    {
        float amtMove = moveSpeed * Time.deltaTime;
        float amtRot = rotSpeed * Time.deltaTime;

        float ver = Input.GetAxis("Vertical");
        float angle = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * ver * amtMove);
        transform.Rotate(Vector3.up * angle * amtRot);
    }
}
