using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnDestroy()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
    }
}
