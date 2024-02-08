using KallaxArduinoObj.Station;

namespace KallaxArduinoObj.DTOS.ContainerDTOs;

public class UpdateContainerDTO : ContainerModel
{
    public new int Id { get; set; }
    public new ContainerStatus ContStatus { get; set; }
    public new DoorStatus DoorStatus { get; set; }
    public new int ContTemp { get; set; } = 1;
    public new int StationId { get; set; }
}
