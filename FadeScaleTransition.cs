using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityExtensions;
using Widgets;

namespace WidgetTransitions
{
    public class FadeScaleTransition : MonoBehaviour
    {
        [SerializeField] private Image background;
        [SerializeField] private Transform layout;
        [SerializeField] private ScriptableObjectGraphicRaycaster raycaster;
        [SerializeField] private UnityWidget widget;
        [SerializeField] private ScriptableObjectWidgetFactory widgetFactory;
        
        public void Hide()
        {
            StartCoroutine(HideAsync());
        }

        private IEnumerator HideAsync()
        {
            raycaster.Enabled = false;
            yield return FadeScaleUtils.HideAsync(background.SetAlpha, layout.SetLocalScale);
            widgetFactory.DestroyWidget(widget);
            raycaster.Enabled = true;
        }
    }
}