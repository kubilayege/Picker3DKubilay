using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public AnimationClip animation;

    public enum Rotation
    {
        left = -1,
        right = 1
    }
    public Rotation rotation;
    public void Update()
    {
       
    }
    public void StartAnimation()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float time = 1.2f;
        while(time > 0)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z),
                                            Quaternion.Euler((int)rotation * 40, -90, 90), 4* Time.deltaTime);
            yield return new WaitForEndOfFrame();
            time -= Time.deltaTime;
        }
    }
}
