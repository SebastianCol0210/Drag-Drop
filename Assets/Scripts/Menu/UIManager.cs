using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button startButton;

        void Start()
        {
            //startButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
            startButton.onClick.AddListener(() => print("Start"));
            
        }

    }
}
