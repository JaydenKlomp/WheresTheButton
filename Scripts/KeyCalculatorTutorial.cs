using UnityEngine;

public class KeyCalculatorTutorial : MonoBehaviour
{
    public BlockFilterTutorial blockFilterRed;
    public BlockFilterTutorial blockFilterGreen;
    public BlockFilterTutorial blockFilterBlue;
    public Animator animatorDoorOpening;

    private void Start()
    {
        blockFilterRed.KeyEnteredChanged += OnKeyEnteredChanged;
        blockFilterGreen.KeyEnteredChanged += OnKeyEnteredChanged;
        blockFilterBlue.KeyEnteredChanged += OnKeyEnteredChanged;
    }

    private void OnDestroy()
    {
        blockFilterRed.KeyEnteredChanged -= OnKeyEnteredChanged;
        blockFilterGreen.KeyEnteredChanged -= OnKeyEnteredChanged;
        blockFilterBlue.KeyEnteredChanged -= OnKeyEnteredChanged;
    }

    private void OnKeyEnteredChanged(bool keyEntered)
    {
        if (blockFilterBlue.KeyEntered && blockFilterGreen.KeyEntered && blockFilterRed.KeyEntered)
        {
            animatorDoorOpening.SetBool("PuzzleSolved", true);
        }
        else
        {
            animatorDoorOpening.SetBool("PuzzleSolved", false);
        }
    }
}