using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    [SerializeField] private int min, seg;
    [SerializeField] private TextMeshProUGUI _timeValue;
    [SerializeField] private float _timeLeft;
    [SerializeField] private bool _timerGo;

    private void Awake()
    {
        _timeLeft = (min * 60) + seg;
        _timerGo = true;
    }
    // Update is called once per frame
    void Update()
    {
     if (_timerGo)
        {
            _timeLeft -= Time.deltaTime;
            if( _timeLeft < 1)
            {
                _timerGo = false;
                SceneManager.LoadScene("GameOver");
            }

            int timeMin = Mathf.FloorToInt(_timeLeft/60);
            int timeSeg = Mathf.FloorToInt(_timeLeft % 60);

            _timeValue.text = $"{timeMin:00}:{timeSeg:00}";
        }   
    }
}
