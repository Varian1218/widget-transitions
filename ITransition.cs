using System.Collections;

namespace WidgetTransitions
{
    public interface ITransition
    {
        IEnumerator HideAsync();
        IEnumerator ShowAsync();
    }
}