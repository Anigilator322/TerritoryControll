namespace Core
{
    public interface ISelectable
    {
        bool Selected { get; set; }
        void Select();
        void OnSelected();
        void OnSelectionEnded();
    }
}
