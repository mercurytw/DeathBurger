using UnityEngine;
using System.Collections;

public class LightMover : MonoBehaviour {

    public Light topLight;
    public Light bottomLight;
    public Light spotLight1;
    public Light spotLight2;
    public Light spotLight3;
    public Light spotLight4;
    public float topLightOnTime;
    public float bottomLightOnTime;
    public float topBottomLightMoveDistance;
    public float topBottomLightMoveSpeed;
    public float spotLight1OnTime;
    public float spotLight2OnTime;
    public float spotLight3OnTime;
    public float spotLight4OnTime;
    private float time;
    private Vector3 topLightEndDistance;
    private Vector3 bottomLightEndDistance;
	// Use this for initialization
	void Start () {
        float xPos = topLight.transform.position.x;
        xPos -= topBottomLightMoveDistance;
        topLightEndDistance = new Vector3(xPos, topLight.transform.position.y, topLight.transform.position.z);
        xPos = bottomLight.transform.position.x;
        xPos += topBottomLightMoveDistance;
        bottomLightEndDistance = new Vector3(xPos, bottomLight.transform.position.y, bottomLight.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;


        //Move Top Light
        if(time > topLightOnTime && topLight.transform.position.x >= topLightEndDistance.x && topLight.isActiveAndEnabled)
        {
            topLight.transform.position = MoveLight(topLight.transform.position, topLightEndDistance);
        }
        if(topLight.isActiveAndEnabled && topLight.transform.position.x <= topLightEndDistance.x)
        {
            topLight.enabled = false;
        }

        //Move Bottom Light
        if (time > bottomLightOnTime && bottomLight.transform.position.x <= bottomLightEndDistance.x && bottomLight.isActiveAndEnabled)
        {
            bottomLight.transform.position = MoveLight(bottomLight.transform.position, bottomLightEndDistance);
        }
        if (bottomLight.isActiveAndEnabled && bottomLight.transform.position.x >= bottomLightEndDistance.x)
        {
            bottomLight.enabled = false;
        }
        if(spotLight1OnTime< time && !spotLight1.isActiveAndEnabled)
        {
            spotLight1.enabled = true;
        }
        if(spotLight2OnTime < time && !spotLight2.isActiveAndEnabled)
        {
            spotLight2.enabled = true;
        }
        if (spotLight3OnTime < time && !spotLight3.isActiveAndEnabled)
        {
            spotLight3.enabled = true;
        }
        if(spotLight4OnTime < time && !spotLight4.isActiveAndEnabled)
        {
            spotLight4.enabled = true;
        }
    }

    Vector3 MoveLight(Vector3 start, Vector3 end)
    {
        return (Vector3.MoveTowards(start, end, topBottomLightMoveSpeed));
    }
}
