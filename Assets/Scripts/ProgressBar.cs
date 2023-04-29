using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int min;
    public int max;
    public int current;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {
        mask.fillAmount += 5;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        
    }


    void GetCurrentFill()
    {

        float currentOffset = current - min;
        float maxOffset = max - min;
        float fillAmount = currentOffset / maxOffset;
        mask.fillAmount = fillAmount;
       


    }
}
