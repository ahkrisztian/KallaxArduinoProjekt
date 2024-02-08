using System.IO.Ports;

namespace KallaxArduinoDataAccess.ArduinoDataAccess;

public class ArduinoAccess : IArduinoAccess, IDisposable
{
    private SerialPort serialPort;

    public ArduinoAccess()
    {
        InitializeSerialPort();
    }
    public async Task<string> ReceivedDataFromArduino()
    {
        if (serialPort is not null && !serialPort.IsOpen)
        {
            InitializeSerialPort();
        }

        try
        {
            while (serialPort is not null && serialPort.IsOpen)
            {
                if (serialPort.BytesToRead > 0)
                {
                    try
                    {
                        string receivedData =  await Task.Run(() => serialPort.ReadLine());

                        if (string.IsNullOrEmpty(receivedData))
                        {
                            return "No Data Received";
                        }

                        CloseConnection();
                        return receivedData;
                    }
                    catch(ObjectDisposedException ox)
                    {
                        CloseConnection();
                        return ox.Message;
                    }                                
                }

                else
                {
                    return "No Bytes To Read";
                }
            }

            return "Connection Closed";
            
        }
        catch (OperationCanceledException)
        {
            return "The operation was canceled.";
        }
        catch (Exception ex)
        {
            return $"An error occurred: {ex.Message}";
        }
    }

    public async Task<string> SentDataToArduino(string data)
    {
        if (serialPort is not null && !serialPort.IsOpen)
        {
            InitializeSerialPort();
        }

        using (serialPort)
        {
            if (serialPort is not null && serialPort.IsOpen)
            {
                await Task.Run(() => serialPort.Write(data));

                return "Data has been sent";

            }
            else
            {
                return "Serial Port is closed";
            }
        }
    }


    private void InitializeSerialPort()
    {
        serialPort = new SerialPort();
        serialPort.PortName = "COM10";
        serialPort.BaudRate = 9600;
        serialPort.DtrEnable = true;
        serialPort.ReadTimeout = 5000;
        serialPort.WriteTimeout = 1000;

        try
        {
            serialPort.Open();
        }
        catch (TimeoutException ex)
        {
            throw new TimeoutException(ex.Message);
        }
    }

    public void CloseConnection()
    {
        serialPort?.Close();
    }

    public void Dispose()
    {
        serialPort?.Close();
    }
}
