using System;
using System.Windows;
using Engine.Models;
using Engine.Models.Temp;
using Engine.Enums;
using View.InteractiveElements;
using View.Interfaces;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace IceEmulator
{
    public partial class MainWindow : Window, IGui
    {
        #region Variables
        private delegate void _Updater(Chassis chassis);
        private delegate void _DateTimeUpdater(TimeSpan currentTime);
        private DateTime _startTime;
        private System.Timers.Timer _timer;
        #endregion
        public MainWindow()
        {
            InitializeComponent();

            _startTime = DateTime.Now;
            SetTimer();//start counting worktime
            
            new Logger(Logger_TextBox);

            #region Event connecting
            StartStop_Button.Click += StartStop_Button_Click;
            #endregion
        }

        #region Chassis to GUI
        /// <summary>
        /// Calling method which update information on GUI
        /// </summary>
        /// <param name="chassis"></param>
        public void Update(Chassis chassis)
        {
            _Updater updater = GuiUpdate;
            Dispatcher.Invoke(updater, new object[] { chassis });
        }
        private void GuiUpdate(Chassis chassis)
        {
            //OnBoardVoltage_TextBox.Text = chassis.***.ToString();
            //AirPressure_TextBox = chassis.***.ToString();
            //OutsideCarTemperature_TextBox = chassis.***.ToString();
            //OilTemperature_TextBox = chassis.***.ToString();
            //CoolantTemperature_Textbox = chassis.***.ToString();
            //RoundPerMinute_TextBox = chassis.***.ToString();

        }
        #endregion

        #region Work time of programm
        /// <summary>
        /// Set and start timer which count work time of programm
        /// </summary>
        private void SetTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += DateTimeUpdate;
            _timer.Start();

        }
        private void DateTimeUpdate(object sourse, ElapsedEventArgs Now)
        {
            var currentTime = Now.SignalTime - _startTime;
            _DateTimeUpdater updater = GuiDateTimeUpdater;
            Dispatcher.Invoke(updater, new object[] { currentTime });
        }
        private void GuiDateTimeUpdater(TimeSpan currentTime)
        {
            string newContent = $"{currentTime.Hours}:{currentTime.Minutes}:{currentTime.Seconds}";
            WorkTime_Label.Content = newContent;
        }
        #endregion

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
