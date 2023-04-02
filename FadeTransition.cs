using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityExtensions;
using Widgets;

namespace WidgetTransitions
{
    public class FadeTransition : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> fade;
        [SerializeField] private ScriptableObjectGraphicRaycaster raycaster;
        [SerializeField] private UnityWidget widget;
        [SerializeField] private ScriptableObjectWidgetFactory widgetFactory;

        public void Hide()
        {
            StartCoroutine(HideAsync());
        }

        public IEnumerator HideAsync()
        {
            raycaster.Enabled = false;
            yield return FadeUtils.HideAsync(fade.Invoke);
            widgetFactory.DestroyWidget(widget);
            raycaster.Enabled = true;
        }

        public void Show()
        {
            StartCoroutine(ShowAsync());
        }

        public IEnumerator ShowAsync()
        {
            raycaster.Enabled = false;
            yield return FadeUtils.ShowAsync(fade.Invoke);
            raycaster.Enabled = true;
        }
    }
}