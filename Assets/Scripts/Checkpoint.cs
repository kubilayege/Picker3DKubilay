using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Checkpoint : MonoBehaviour
{
    public Stick[] sticks;
    public TextMeshProUGUI cpText;
    public GameObject platform;
    public float countTime;
    public float platformRaiseTime;

    public int checkPointMission;
    Coroutine counting;
    int count;

    public void Start()
    {
        cpText.text = "0/" + checkPointMission.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.main.ChangeGameState(GameStates.CheckPointReached);
            Player.main.StopRB();
            GetComponent<BoxCollider>().isTrigger = true;
            if(counting == null)
                StartCoroutine(StartCounting());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Part"))
            count++;
    }

    IEnumerator StartCounting()
    {
        count = 0;
        while (countTime > 0)
        {
            cpText.text = count.ToString() + "/" + checkPointMission.ToString(); 
            yield return new WaitForEndOfFrame();
            countTime -= Time.deltaTime;
        }

        if (count >= checkPointMission)
        {
            //Pass
            while (platformRaiseTime > 0)
            {
                platform.transform.localPosition = Vector3.Lerp(platform.transform.localPosition, new Vector3(0, 4.56f, 0), 3f * Time.deltaTime);
                yield return new WaitForEndOfFrame();
                platformRaiseTime -= Time.deltaTime;
            }
            
            platform.GetComponent<BoxCollider>().isTrigger = false;
            
            foreach (var stick in sticks)
            {
                stick.StartAnimation();
                Debug.Log("animstick");
            }
            GameManager.main.ChangeGameState(GameStates.Playing);
        }

    }
}
