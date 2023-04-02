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
        [SerializeField] private ScriptableObjectGraphicRaycaster raycaster;
        [SerializeField] private UnityEvent<Vector3> scale;
        [SerializeField] private UnityWidget widget;
        [SerializeField] private ScriptableObjectWidgetFactory widgetFactory;

        public void Hide()
        {
            StartCoroutine(HideAsync());
        }

        public IEnumerator HideAsync()
        {
            raycaster.Enabled = false;
            yield return FadeScaleUtils.HideAsync(fade.Invoke, scale.Invoke);
            widgetFactory.DestroyWidget(widget);
            raycaster.Enabled = true;
        }
    }
}