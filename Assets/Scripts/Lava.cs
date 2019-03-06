using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public Vector2 direction;
    [SerializeField] private float resetPosition = 143f;
    [SerializeField] private float startPosition = -143f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(direction.normalized * 0.015f);
        if (transform.localPosition.x >= resetPosition)
        {
            Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
