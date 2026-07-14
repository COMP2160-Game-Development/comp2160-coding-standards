using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Timer {

    public float period;
    public bool cycle = true;
    
    private float time;    

    public static implicit operator Timer(float period) => new Timer(period);

    public Timer(float period) {
        this.period = period;
        this.time = period;
    }

    public void Reset() {
        time = period;
    }

    public bool Tick() {
        time -= Time.deltaTime;

        if (time <= 0) {
            if (cycle){
                time += period;
            }
            return true;
        }
        return false;
    }
}
