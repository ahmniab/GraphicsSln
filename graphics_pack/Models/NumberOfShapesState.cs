namespace graphics_pack.Models;

public class NumberOfShapesState
{
    public event Action OnChange;

    public void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}