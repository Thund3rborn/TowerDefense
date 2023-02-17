using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public LineRenderer line;
    public float speed = 1f;

    private int currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = line.positionCount -1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPoint = line.GetPosition(currentPoint);
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        if (transform.position == targetPoint)
        {
            currentPoint -= 1;
            if(currentPoint < 0)
                currentPoint= 0;
        }

        transform.LookAt(targetPoint);
    }
}
