public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Hidden words show one underscore per letter; punctuation stays visible.
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        char[] characters = _text.ToCharArray();

        for (int i = 0; i < characters.Length; i++)
        {
            if (char.IsLetter(characters[i]))
            {
                characters[i] = '_';
            }
        }

        return new string(characters);
    }
}
