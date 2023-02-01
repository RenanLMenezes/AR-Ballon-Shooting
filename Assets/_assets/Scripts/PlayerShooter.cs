using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private Camera arCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = arCam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log(raycastHit.transform.name);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var obj = hit.collider.gameObject;
                if (obj.tag == "RedBallon")
                {
                    GameManager.points += 5;
                }
                if (obj.tag == "BlueBallon")
                {
                    GameManager.points += 3;
                }
                if (obj.tag == "GreenBallon")
                {
                    GameManager.points += 1;
                }
                Destroy(obj);
            }
        }
    }
}
