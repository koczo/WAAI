namespace WAAI.Core.Services;

public class MessageService
{
    public event Action<string, object>? OnMessage;

    public void SendMessage(string messageType, object payload)
    {
        OnMessage?.Invoke(messageType, payload);
    }

    public void Subscribe(Action<string, object> action)
    {
        OnMessage += action;
    }

    public void Unsubscribe(Action<string, object> action)
    {
        OnMessage -= action;
    }
}
