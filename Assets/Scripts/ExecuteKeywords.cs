using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteKeywords : MonoBehaviour {

    public void ExecuteAddPoint()
    {
        var gazePosition = GameObject.Find("GlobalCursor").transform.position;

        DistanceCalculationGmObjGmObj.Instance.AddPoint(gazePosition);
    }

    public void ExecuteClearPoints()
    {
        DistanceCalculationGmObjGmObj.Instance.ClearPoints();
    }
}
