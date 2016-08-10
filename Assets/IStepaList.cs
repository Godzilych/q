interface IStepaATDVector
{
    string GetAt(int index);
    int GetLength();

    void AddToEnd(string value);
    void SetAt(int index, string value);
    void AddAt(int index, string value);
    void RemoveAt(int index);
    void Clear();
}
