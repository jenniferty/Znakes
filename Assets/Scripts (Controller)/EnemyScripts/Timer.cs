using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject bomb;
    private float time;
    public float getTime()
    {
        return this.time;
    }
    public void setTime(float time)
    {
        this.time = time;
    }
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
        //transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    string GetBombTime()
    {
        setTime(bomb.GetComponent<Explosion>().getBombTimer());
        return getTime().ToString("#.##");
    }
}
