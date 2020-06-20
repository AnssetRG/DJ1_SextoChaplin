using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private List<string> tags;
    // Start is called before the first frame update
    void Start()
    {
        tags = new List<string>(new string[] { "Bird", "Brick", "Pig" });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tags.IndexOf(other.gameObject.tag) > -1)
        {
            Destroy(other.gameObject);
        }
    }
}
