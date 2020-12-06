using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    private IEnumerator FadeIn()
    {
        var t = 1f;
        
        while (t > 0f)
        {
            t -= Time.deltaTime;
            var alpha = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, alpha);
            yield return 0; // wait a frame
        }
    }

    private IEnumerator FadeOut(string scene)
    {
        var t = 0f;
        
        while (t < 1f)
        {
            t += Time.deltaTime;
            var alpha = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, alpha);
            yield return 0; // wait a frame
        }
        SceneManager.LoadScene(scene);
    }
}
