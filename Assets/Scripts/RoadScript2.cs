using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript2 : MonoBehaviour
{

    [SerializeField] public float speed = 2f;


    private void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        if (transform.position.y <= -11.81f)
        {
            transform.position = new Vector2(-0.51f, 14.18289f);
        }
    }
}
