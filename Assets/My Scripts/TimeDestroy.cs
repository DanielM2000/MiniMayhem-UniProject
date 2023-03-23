using UnityEngine;
using System.Collections;
public class TimeDestroy : MonoBehaviour
{
    void Update()
    {
        float lifetime = 3.0f;
        {
            Destroy(gameObject, lifetime);
        }
    }
}