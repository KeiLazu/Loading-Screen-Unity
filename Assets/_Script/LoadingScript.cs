/**
 * reference: https://www.youtube.com/watch?v=oNf3gdjiEEQ
 * 
 * i made this only for educational & research only purpose
 * so i can understand every aspect in it
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

    AsyncOperation _asyncOperation;

    [Header("Initialize")]
    public GameObject _loadingScreen;
    public Slider _progBar;
    public Text _loadingText;

    [Header("Fake Loading")]
    public bool _fakeLoading = false;
    public float _fakeIncrement = 0f;
    public float _fakeTiming = 0f;

    [Header("Scene")]
    [SerializeField]
    int _targetScene;

    public void ChooseLevel()
    {
        _loadingScreen.SetActive(true);
        _progBar.gameObject.SetActive(true);
        _loadingText.gameObject.SetActive(true);

        _loadingText.text = "Loading";

        if (!_fakeLoading)
        {
            StartCoroutine(LoadLevelWithRealProgress());
        }
        else
        {
            StartCoroutine(LoadLevelWithFakeProgress());
        }

    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);

        _asyncOperation = SceneManager.LoadSceneAsync(_targetScene);
        _asyncOperation.allowSceneActivation = false;

        while(!_asyncOperation.isDone)
        {
            _progBar.value = _asyncOperation.progress;

            if (_asyncOperation.progress == 0.9f)
            {
                _progBar.value = 1f;
                _loadingText.text = "Press 'F' to Continue";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _asyncOperation.allowSceneActivation = true;
                }
            }

            Debug.Log(_asyncOperation.progress);
            yield return null;

        }

    }

    IEnumerator LoadLevelWithFakeProgress()
    {
        yield return new WaitForSeconds(1);

        while (_progBar.value != 1f)
        {
            _progBar.value += _fakeIncrement;
            yield return new WaitForSeconds(_fakeTiming);
        }

        while (_progBar.value == 1f)
        {
            _loadingText.text = "Press 'F' to Continue";
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(_targetScene);
            }
            yield return null;
        }
    }

    /**
     * this one below is for using image, and text indicator for show the percentage in text
     */
     
    /*public Image loadingImage;
    AsyncOperation ao;
    public Text textIndicator;

    void Start()
    {
        loadingImage.gameObject.SetActive(false);
        loadingImage.fillAmount = 0f;
        textIndicator.text = "";
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);
        ao = SceneManager.LoadSceneAsync("Level1");
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {

            loadingImage.fillAmount = ao.progress;
            loadingText.text = "Loading  " + (int)(ao.progress * 100) + "%";
            if (ao.progress == 0.9f)
            {
                loadingImage.fillAmount = 1f;
                loadingText.text = "Loading Done ";
                ao.allowSceneActivation = true;
            }
            Debug.Log(ao.progress);
            yield return null;
        }
    }*/

}
