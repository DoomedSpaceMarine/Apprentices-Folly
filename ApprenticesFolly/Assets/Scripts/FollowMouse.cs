using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = Input.mousePosition;
    }
}
