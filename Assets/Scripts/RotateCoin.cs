using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    private void Spin()
    {
        transform.Rotate(0, 0, 1, Space.Self);
    }

    private void FixedUpdate()
    {
        Spin();
    }

}
