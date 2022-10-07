using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    // Start is called before the first frame update
    public float[] inputs;
    public int answer;

    void Start()
    {

        
    }

    public void setup(float x, float y, int a)
    {
        inputs = new float[3];
        inputs[0] = x;
        inputs[1] = y;
        inputs[2] = 1; //bias
        answer = a;
    }

    float f(float x)
    {
        return 2 * x + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
