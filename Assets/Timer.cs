using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject bomb;
    public float time;
    public TextMeshProUGUI timer;
    public GameObject timerUI;
    // Start is called before the first frame update
    void Start()
    {
        timer.text = GetBombTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = GetBombTime();
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    string GetBombTime()
    {
        time = bomb.GetComponent<Explosion>().bombTimer;
        return time.ToString("#.##");
    }
}
