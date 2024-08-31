public interface IMediator 
{
    void SendMessage(Shape sender, string message);
    void RegisterShape(Shape toy);    
}
