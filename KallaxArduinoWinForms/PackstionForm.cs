using KallaxArduinoDataAccess.ArduinoDataAccess;
using KallaxArduinoDataAccess.PackageDataAccess;
using KallaxArduinoDataAccess.StationDataAccess;
using KallaxArduinoObj.DTOS.ContainerDTOs;
using KallaxArduinoObj.Package;
using KallaxArduinoObj.Station;
using KallaxArduinoObj.User;

namespace KallaxArduinoWinForms;

public partial class PackstionForm : Form
{
    private readonly IStationAccess dataAccess;
    private readonly IArduinoAccess arduinoAccess;
    private readonly IPackageAccess packageAccess;
    private readonly IContainerAccess containerAccess;

    private System.Windows.Forms.Timer timer;

    private ContainerModel selectedContainerModel;
    private UserModel SelectedUser { get; set; }

    private List<UserModel> users = new();
    public List<ContainerWithPackages> containers { get; set; } = new();

    private List<ContainerWithPackages> UserContainer { get; set; } = new();

    public PackstionForm(IStationAccess dataAccess, IArduinoAccess arduinoAccess, IPackageAccess packageAccess,
                            IContainerAccess containerAccess)
    {

        InitializeComponent();
        this.dataAccess = dataAccess;
        this.arduinoAccess = arduinoAccess;
        this.packageAccess = packageAccess;
        this.containerAccess = containerAccess;
        stationModel();

        timer = new System.Windows.Forms.Timer();
        timer.Interval = 5000;

        this.Load += SetGroupBoxToBasic;

    }

    public async void stationModel()
    {
        var station = await dataAccess.GetStationById(1);

        if (station is not null)
        {
            packStationNamegroupBox.Text = station.Name;

            users.AddRange(station.Users);
            containers.AddRange(station.ContainerModels);


        }

        packStationNamegroupBox.Text = "";
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
        if (int.TryParse(userNumbertextBox.Text, out int convertedNumber))
        {
            SelectedUser = (users.Where(u => u.UserID == convertedNumber).FirstOrDefault());

            if (SelectedUser is not null)
            {
                nextButton.Text = "Next";
                packageNumberAndPassswordgroupBox.Show();
                UserContainer = containers.Where(i => i.PackageModel.UserId == SelectedUser.Id && i.PackageModel.PackStatus != PackageStatus.Collected).ToList();

                packageListBox.Items.Clear();
                packageListBox.Items.AddRange(UserContainer.ToArray());
                packageListBox.DisplayMember = "DisplayPackageName";
            }
            else
            {
                userNumbertextBox.Text = "There is no package";
            }
        }
        else
        {
            userNumbertextBox.Text = "Invalid number";
        }
    }

    private void collectButton_Click(object sender, EventArgs e)
    {
        if (int.TryParse(packageNumbertextBox.Text, out int convertedNumber))
        {
            if (SelectedUser is not null)
            {
                if (SelectedUser.Password == passwordtextBox.Text && UserContainer.Any(p => p.PackageModel.Number == convertedNumber))
                {
                    packageListBox.Show();
                }
            }
        }
        else
        {
            MessageBox.Show("Wrong Package Number");
        }

    }

    private async void openContainerButton_Click(object sender, EventArgs e)
    {
        string selectedContainer = "";

        if (selectedContainerModel is not null)
        {
            selectedContainer = (selectedContainerModel.Id - 2).ToString();

            await arduinoAccess.SentDataToArduino(selectedContainer);

            bool arduionoOutputbool = true;

          
            while (arduionoOutputbool)
            {
                string arduionoOutput = await arduinoAccess.ReceivedDataFromArduino();

                if (arduionoOutput is not null && arduionoOutput == "Closed\r")
                {

                    arduionoOutputbool = false;

                    var container = containers.FirstOrDefault(i => i.Id == selectedContainerModel.Id);

                    var package = container.PackageModel;

                    package.PackStatus = PackageStatus.Collected;
                    package.CollectedDate = DateTime.Now;

                    await packageAccess.SetPackageStatus(package);

                    var updateContainerDTO = new ContainerModel
                    {
                        Id = container.Id,
                        ContStatus = ContainerStatus.Empty,
                        ContTemp = container.ContTemp,
                        DoorStatus = DoorStatus.Closed,
                        StationId = container.StationId
                    };

                    await containerAccess.SetContainerStatus(updateContainerDTO);

                    await containerAccess.SetContainerDoorStatus(updateContainerDTO);

                }
                else
                {
                    collectYourPackagegroupBox.Hide();
                    doorStatusGroupBox.Show();

                    await containerAccess.SetContainerDoorStatus(new UpdateContainerDTO
                    {
                        Id = selectedContainerModel.Id,
                        ContStatus = ContainerStatus.Full,
                        ContTemp = selectedContainerModel.ContTemp,
                        DoorStatus = DoorStatus.Open,
                        StationId = selectedContainerModel.StationId

                    });

                    statusLabel.Invoke((MethodInvoker)delegate
                    {
                        statusLabel.Text = $"Please collect Your package. Door {selectedContainer} is open.";
                    });
                }
            }
          
            timer.Tick += new EventHandler(SetGroupBoxToBasic);
            timer.Start();

            ShowGoodByeLabel(this, EventArgs.Empty);
            
        }
        else
        {
            MessageBox.Show("Please select any Container!");
        }

    }

    private void packageListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedContainerModel = packageListBox.SelectedItem as ContainerModel;

        if (selectedContainerModel is not null)
        {
            //-1
            openContainerButton.Show();
            openContainerButton.Text = $"Open the Container Nr. {selectedContainerModel.Id - 2}";
        }

    }

    private void ShowGoodByeLabel(object sender, EventArgs e)
    {
        statusLabel.Text = $"Thank you! Have a nice day!";
    }

    private void SetGroupBoxToBasic(object sender, EventArgs e)
    {
        timer.Stop();
        packageNumberAndPassswordgroupBox.Hide();
        packageListBox.Hide();
        openContainerButton.Hide();
        doorStatusGroupBox.Hide();
        collectYourPackagegroupBox.Show();
        clearTextBoxescollectYourPackagegroupBox();
    }

    private void clearTextBoxescollectYourPackagegroupBox()
    {
        foreach (Control control in collectYourPackagegroupBox.Controls)
        {
            if(control is GroupBox)
            {
                foreach (Control control2 in control.Controls)
                {
                    if (control2 is TextBox textBox)
                    {
                        textBox.Text = string.Empty;
                    }
                }
            }                   
        }
    }
}
