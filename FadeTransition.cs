using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityExtensions;

namespace WidgetTransitions
{
    public class FadeTransition : MonoBehaviour, ITransition
    {
        [SerializeField] private UnityEvent<bool> interactable;
        [SerializeField] private UnityEvent<float> fade;
        [SerializeField] private UnityEvent<bool> visible;

        public void Hide()
        {
            StartCoroutine(HideAsync());
        }

        public IEnumerator HideAsync()
        {
            interactable.Invoke(false);
            yield return FadeUtils.HideAsync(fade.Invoke);
            visible.Invoke(false);
            interactable.Invoke(true);
        }

        public void Show()
        {
            StartCoroutine(ShowAsync());
        }

        public IEnumerator ShowAsync()
        {
            interactable.Invoke(false);
            visible.Invoke(true);
            yield return FadeUtils.ShowAsync(fade.Invoke);
            interactable.Invoke(true);
        }
    }
}