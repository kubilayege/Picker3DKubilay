using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset;
    public float camFollowSpeed;

    private void Start()
    {
        offset = Player.main.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsPlaying())
        {
            transform.position = new Vector3(0, (Player.main.transform.position - offset).y, (Player.main.transform.position - offset).z);
        }
    }
}
