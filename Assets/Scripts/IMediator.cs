public interface IMediator 
{
    void SendMessage(Shape sender, string message);
    void RegisterToy(Shape toy);    
}
