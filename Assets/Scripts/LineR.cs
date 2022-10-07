using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineR : MonoBehaviour
{

    public GameObject myPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
       /* for(int i = 0; i < 5; i++)
        {
            Instantiate(myPrefab, new Vector3(i+3, 0, 0), Quaternion.identity);
        }
       */

        LineRenderer l = gameObject.AddComponent<LineRenderer>();

        List<Vector3> pos = new List<Vector3>();
        pos.Add(new Vector3(-10, -19));      
        pos.Add(new Vector3(10, 21));
        l.startWidth = 1f;
        l.endWidth = 1f;

 
        l.SetPositions(pos.ToArray());
        l.useWorldSpace = true;

        setup();
    }

    Perceptron ptron;
    Trainer[] training = new Trainer[500];
    int count = 0;
    void setup()
    {
        ptron = new Perceptron();
        for(int i=0; i < training.Length; i++)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            int answer = 1;
            if (y < f(x)) answer = -1;
            training[i] = new Trainer();
            training[i].setup(x, y, answer);
        }

        draw();
    }

    float f(float x)
    {
        return 2 * x + 1;
    }

    public void draw()
    {
        ptron = new Perceptron();
        ptron.Init();

        for (int i = 0; i < training.Length; i++)
        {
            ptron.train(training[i].inputs, training[i].answer);
            
        }

        Guess();

    }

    void Guess()
    {
        for(int i = 0; i < 40; i++)
        {
            float[] punt = new float[3];
            punt[0] = Random.Range(-10,10);
            punt[1] = Random.Range(-10, 10); 
            punt[2] = 1;
            int res = ptron.feedForward(punt);
            if(res > 0)
            {
                myPrefab.GetComponent<CircleMaterial>().ChangeMaterial(false);
            }
            else
            {
                myPrefab.GetComponent<CircleMaterial>().ChangeMaterial(true);
            }
            Instantiate(myPrefab, new Vector3(punt[0],punt[1], 0), Quaternion.identity);


        }
    }
    // Update is called once per frame
    void Update()
    {

        
    }
}
