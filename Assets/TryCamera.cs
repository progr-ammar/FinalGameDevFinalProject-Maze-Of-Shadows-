using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerposition = Player.transform.position;
        float distance = Vector3.Distance(playerposition, transform.position);
        float steps = distance * 2 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerposition, steps);

        if (Input.GetKey(KeyCode.M))
        {
            transform.Rotate(0, 3f, 0);
        }
        if (Input.GetKey(KeyCode.N))
        {
            transform.Rotate(0, -3f, 0);
        }
    }
}
