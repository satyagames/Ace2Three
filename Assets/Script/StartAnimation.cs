using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAnimation : MonoBehaviour
{
    public GameObject Logo;
    public GameObject Lines;
    public GameObject[] LinesHelper;

    public void Start()
    {
        ItweenSimpleVersion.Scale(Lines, 1, 1, 1, 2);
        ItweenSimpleVersion.Scale(Logo, 1, 1, 1, 7);
        foreach (GameObject c in LinesHelper)
        {
            StartCoroutine(FadeImage(true, c.GetComponent<Image>(),4));
        }

    }
    public float test;

    IEnumerator FadeImage(bool fadeAway, Image img,int d)
    {
        yield return new WaitForSeconds(d);
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
