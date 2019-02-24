using System.Collections;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    public GameObject PlayerCamera;

    void Start()
    {
        StartCoroutine("SetPlayerCamera");
    }

    IEnumerator SetPlayerCamera()
    {
        yield return new WaitUntil(() => State.CurrentPlayer.GameObject.transform.Find("PlayerCamera"));
        PlayerCamera = State.CurrentPlayer.GameObject.transform.Find("PlayerCamera").gameObject;
    }

    void LateUpdate()
    {
        if (PlayerCamera)
        {
            transform.LookAt(transform.position + PlayerCamera.transform.rotation * Vector3.forward, PlayerCamera.transform.rotation * Vector3.up);
        }
    }
}