using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    //this thing's position(camera) will be same as car's position
    void LateUpdate()
    {
        transform.position=thingToFollow.transform.position + new Vector3 (0,0,-10);
    }
}
