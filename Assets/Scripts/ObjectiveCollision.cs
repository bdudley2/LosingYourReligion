using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name[0] == 'O') {
            other.gameObject.transform.position = new Vector3(1006, 1027, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
