using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    public Transform foregroundTransform;
    public Transform catchupTransform;
    public float catchupSpeed = 10.0f;
    
    [Range(0f,1f)]
    public float percentage = 1f;

    void Update(){
        foregroundTransform.localScale = new Vector3(percentage,1f,1f);

        float catchupSize = Mathf.Lerp(catchupTransform.localScale.x, percentage, Time.deltaTime*catchupSpeed);
        if(catchupSize < percentage){
            catchupSize = percentage;
        }
        catchupTransform.localScale = new Vector3(catchupSize,1.0f,1.0f);
    }
}
