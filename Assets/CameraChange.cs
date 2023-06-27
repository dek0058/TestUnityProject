using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera main_camera;

    public CinemachineVirtualCameraBase DefaultVCam;

    public CinemachineVirtualCameraBase LockonVCam;

    public Rigidbody character_rigidbody;

    public Rigidbody target_rigidbody;

    public float speed = 360;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = main_camera.transform.forward;
        forward.y = 0;

        Vector3 right = main_camera.transform.right;
        right.y = 0;

        Vector3 dir = target_rigidbody.transform.position - character_rigidbody.transform.position;
        dir.y = 0;
        Quaternion quaternion1 = Quaternion.LookRotation(dir, Vector3.up);

        character_rigidbody.MoveRotation(quaternion1);

        if (Input.GetKey(KeyCode.W)) {
            forward = transform.position + (forward * speed * Time.deltaTime );
            Quaternion quaternion = Quaternion.LookRotation(forward);
            character_rigidbody.MovePosition(forward);
        }
        else if(Input.GetKey(KeyCode.S)) {
            forward = transform.position - ( forward * speed * Time.deltaTime );
            character_rigidbody.MovePosition(forward);
        }

        if (Input.GetKey(KeyCode.D)) {
            right = transform.position + ( right * speed * Time.deltaTime );
            character_rigidbody.MovePosition(right);
        }
        else if(Input.GetKey(KeyCode.A)) {
            right = transform.position - ( right * speed * Time.deltaTime );
            character_rigidbody.MovePosition(right);
        }
        
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(LockonVCam.Priority == 20) {
                LockonVCam.Priority = 0;
            } else {
                LockonVCam.Priority = 20;
            }
        }

    }
}
