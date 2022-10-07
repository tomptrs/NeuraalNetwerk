using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour
{
    // Start is called before the first frame update
    float[] weights;
    public int Aantal = 3;
    float c = 0.01f;

    void Start()
    {

    }

    public void Init()
    {

        weights = new float[Aantal];
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(-1, 1);
        }
    }


    public int feedForward(float[] inputs)
    {
        float sum = 0;
        for(int i = 0; i < weights.Length; i++)
        {
            sum += inputs[i] * weights[i];
        }
        return activate(sum);
    }

    private int activate(float sum)
    {
        if (sum > 0) return 1;
        return -1;
    }

    public void train(float[] inputs, int desired)
    {
        int guess = feedForward(inputs);
        float error = desired - guess;
        for(int i = 0; i < weights.Length; i++)
        {
            weights[i] += c * error * inputs[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
