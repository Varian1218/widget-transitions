using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityExtensions;
using Widgets;

namespace WidgetTransitions
{
    public class FadeScaleTransition : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> fade;
        [SerializeField] private UnityEvent postTranslate;
        [SerializeField] private UnityEvent preTranslate;
        [SerializeField] private UnityEvent<Vector3> scale;

        public void Hide()
        {
            StartCoroutine(HideAsync());
        }

        public IEnumerator HideAsync()
        {
            preTranslate.Invoke();
            yield return FadeScaleUtils.HideAsync(fade.Invoke, scale.Invoke);
            postTranslate.Invoke();
        }

        public void Show()
        {
            StartCoroutine(ShowAsync());
        }

        public IEnumerator ShowAsync()
        {
            preTranslate.Invoke();
            yield return FadeScaleUtils.ShowAsync(fade.Invoke, scale.Invoke);
            postTranslate.Invoke();
        }
    }
}