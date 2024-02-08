namespace KallaxArduinoObj.Package;

public enum PackageStatus
{
    Collected,
    NotCollected

}
public class PackageModel
{
    public int Id { get; set; }
    public int Number { get; set; }
    public DateTime PurchasedDate { get; set; }
    public DateTime LastDateToCollectDate { get; set; }
    public DateTime CollectedDate {  get; set; }
    public PackageStatus PackStatus { get; set; }
    public string IdToCollectPackage { get; set; }
    public int UserId { get; set; }
    public int StationId { get; set; }
    public int ContainerId { get; set; }
}
