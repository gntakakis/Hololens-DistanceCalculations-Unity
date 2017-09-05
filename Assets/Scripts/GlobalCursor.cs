using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCursor : MonoBehaviour {

    private MeshRenderer meshRenderer;

    void Start ()
    {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        
        var gazePosition = GameObject.Find("GlobalCursor").transform.position;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            meshRenderer.enabled = true;

            this.transform.position = hitInfo.point;
            
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            //Display distance (Hololens - Cursor)
            float distance = Vector3.Distance(headPosition, gazePosition);
            TextMessage.Instance.ChangeTextMessage(string.Format("Distance: {0}", distance >= 1.0f ? distance.ToString("####0.0") + "m" : distance.ToString("0.00") + "cm" ));
        }
        else
        {
            meshRenderer.enabled = false;
            TextMessage.Instance.ChangeTextMessage(string.Empty);
        }
    }
}
