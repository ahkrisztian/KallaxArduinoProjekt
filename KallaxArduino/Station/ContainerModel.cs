using KallaxArduinoObj.Package;

namespace KallaxArduinoObj.Station;

public enum ContainerStatus
{
    Full,
    Empty
}

public enum DoorStatus
{
    Open,
    Closed
}
public class ContainerModel
{
    public int Id { get; set; }
    public ContainerStatus ContStatus { get; set; } = ContainerStatus.Empty;
    public DoorStatus DoorStatus { get; set; } = DoorStatus.Closed;
    public int ContTemp { get; set; } = 1;
    public int StationId { get; set; }

    
}
