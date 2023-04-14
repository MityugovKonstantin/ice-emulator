using GUI;
using System;
using System.Windows;
using Engine.Models;
using Engine.Models.Temp;
using Engine.Enums;
using View.InteractiveElements;

namespace IceEmulator
{
    //ВЫВОД ИЗМЕНЕНИЙ НА ГУИ
    public partial class MainWindow : Window, IGui
    {
        public MainWindow()
        {
            InitializeComponent();

            new Logger(Logger_TextBox);

            #region Event connecting
            //StartStop_Button.Click += StartStop_Button_Click;
            #endregion
        }
        #region Events
        public event EventHandler<Chassis> Start;
        //Инвокнуть стоп на стопе
        public event EventHandler Stop;
        private void StartStop_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!StartStop_Button.GetIsEnable())
            {
                #region start value
                bool isTemperatureParse = float.TryParse(OutsideTemperature_TextBox.Text, out float temperature);
                if (!isTemperatureParse) throw new ArgumentException("Outside temperature invalid!");

                bool isRotationParse = float.TryParse(RollAngle_TextBox.Text, out float rotation);
                if (!isRotationParse) throw new ArgumentException("Roll angle invalid!");

                StartValue startValue = new StartValue()
                {
                    Temperature = temperature,
                    Rotation = rotation,
                    IsHandBrake = HandBrake_CheckBox.IsChecked == true ? true : false,
                    RockerPositions = MapRocker(Rocker_ComboBox.Text),
                    MovementType = MapMovement(Movement_ComboBox.Text)
                };
                #endregion

                #region developer fields
                bool isOilLevelParse = float.TryParse(OilLevel_TextBox.Text, out float oilLevel);
                if (!isOilLevelParse) throw new ArgumentException("Oil level invalid!");

                bool isOilPressureParse = float.TryParse(OilPressure_TextBox.Text, out float oilPressure);
                if (!isOilPressureParse) throw new ArgumentException("Oil pressure invalid!");

                bool isCoolantLevelParse = float.TryParse(CoolantLevel_TextBox.Text, out float coolantLevel);
                if (!isCoolantLevelParse) throw new ArgumentException("Coolant level invalid!");

                DeveloperFields developerFields = new DeveloperFields()
                {
                    OilValue = oilLevel,
                    OilPressure = oilPressure,
                    CoolantValue = coolantLevel,
                    IsHeater = Heater_CheckBox.IsChecked == true ? true : false
                };
                #endregion

                // build object (DTO (Data Transfer Object) - create object to send it in other module)
                Chassis chassis = new Chassis()
                {
                    StartValue = startValue,
                    DeveloperFields = developerFields
                };

                // call event
                Start?.Invoke(sender, chassis);
            }
            else Stop?.Invoke(sender, EventArgs.Empty);
        }
        #endregion

        #region Mappers
        private RockerPositions MapRocker(string value)
        {
            if (value == "N") return RockerPositions.NeutralGear;
            else if (value == "1") return RockerPositions.FirstGear;
            else if (value == "2") return RockerPositions.SecondGear;
            else if (value == "3") return RockerPositions.ThirdGear;
            else if (value == "4") return RockerPositions.FourthGear;
            else throw new Exception("Rocker mapping failed");
        }
        private MovementType MapMovement(string value)
        {
            if (value == "Парковка") return MovementType.Parcking;
            else if (value == "Остановка при работающем двигателе") return MovementType.StopWithEngineRunning;
            else if (value == "Езда вперёд") return MovementType.Rectilinear;
            else if (value == "Езда назад") return MovementType.Back;
            else if (value == "Круговая езда") return MovementType.Circular;
            else throw new Exception("Movement mapping failed");
        }
        #endregion
    }
}
