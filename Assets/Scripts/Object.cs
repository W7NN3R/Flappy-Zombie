using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] byte objectSpeed = 3;
    [SerializeField] private float resetPosition = 50f;
    [SerializeField] private float startPosition = -49f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!gameManager.instance.GameOver)
        {
            transform.Translate(Vector3.right * (objectSpeed * Time.deltaTime));

            if (transform.localPosition.x >= resetPosition)
            {
                Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
        
    }
}
