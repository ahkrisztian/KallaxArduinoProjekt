using KallaxArduinoObj.Station;

namespace KallaxArduinoObj.DTOS.ContainerDTOs;

public class UpdateContainerDoorStatusDTO : ContainerModel
{
    public new int Id { get; set; }
    public new DoorStatus DoorStatus { get; set; }
}
