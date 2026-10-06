using UnityEngine;
using UnityEngine.SceneManagement;

public class PremiseScript : MonoBehaviour
{
    private bool keypressed = false;

    private void Update()
    {
       if (!keypressed && Input.anyKeyDown)
        {
            keypressed = true;
            SceneManager.LoadScene("SampleScene");
        }
    }
}