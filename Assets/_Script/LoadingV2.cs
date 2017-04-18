using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingV2 : MonoBehaviour {

    AsyncOperation _operation;

    [SerializeField]
    Image _buttonImage;

    [Header("Init")]
    public GameObject _loadingScreen;
    public Image _imageLoading;
    public Text _loadingText, _loadingPercentage;

    [Header("Scene Management")]
    [SerializeField]
    int _targetScene;

    private void Start()
    {
        _buttonImage.alphaHitTestMinimumThreshold = 0.7f;
    }

    public void GoToLevel()
    {
        _loadingScreen.SetActive(true);
        _imageLoading.gameObject.SetActive(true);
        _loadingText.gameObject.SetActive(true);

        _loadingText.text = "Loading . . .";
        _imageLoading.fillAmount = 0f;

        StartCoroutine(LoadingLevel());

    }

    IEnumerator LoadingLevel()
    {
        yield return new WaitForSeconds(1);

        _operation = SceneManager.LoadSceneAsync(_targetScene);
        _operation.allowSceneActivation = false;

        while (!_operation.isDone)
        {
            _imageLoading.fillAmount = _operation.progress;
            _loadingPercentage.text = (int)(_operation.progress * 100) + "%";

            if (_operation.progress == 0.9f)
            {
                _loadingPercentage.text = "100%";
                _imageLoading.fillAmount = 1f;
                _loadingText.text = "Press F to Continue";

                if (Input.GetKeyDown(KeyCode.F))
                {
                    _operation.allowSceneActivation = true;
                }

            }
            //Debug.Log(_operation.progress);
            yield return null;

        }

    }

}
