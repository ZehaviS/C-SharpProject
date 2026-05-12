namespace BO;

[System.Serializable]
public class BLException : System.Exception
{
    public BLException(string? message) : base(message) { }
    public BLException(string message, System.Exception innerException) : base(message, innerException) { }
}
