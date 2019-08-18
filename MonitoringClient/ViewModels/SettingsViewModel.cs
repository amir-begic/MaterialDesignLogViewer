using System.Windows.Input;
using MonitoringClient.Models;
using MonitoringClient.Services;

namespace MonitoringClient.ViewModels
{
    public interface ISettingsViewModel
    {
        void TestDatabaseConnection();
    }

    public class SettingsViewModel : ISettingsViewModel
    {
        private readonly IDatabaseService<LogEntryModel> _databaseService;
        private ICommand _testDatabaseConnectionCommand;

        public SettingsViewModel(IDatabaseService<LogEntryModel> databaseService)
        {
            _databaseService = databaseService;
            Database = Database;
            Username = Username;
            Hostname = Hostname;
        }

        public string Database
        {
            get => Properties.Settings.Default.Database != null ? Properties.Settings.Default.Database : "";
            set => Properties.Settings.Default.Database = value;
        }

        public string Username
        {
            get => Properties.Settings.Default.Username != null ? Properties.Settings.Default.Username : "";
            set => Properties.Settings.Default.Username = value;
        }

        public string Hostname
        {
            get => Properties.Settings.Default.Hostname != null ? Properties.Settings.Default.Hostname : "";
            set => Properties.Settings.Default.Hostname = value;
        }

        public ICommand TestDatabaseConnectionCommand
        {
            get
            {
                if (_testDatabaseConnectionCommand == null)
                {
                    _testDatabaseConnectionCommand = new RelayCommand(
                        p => true,
                        p => TestDatabaseConnection());
                }

                return _testDatabaseConnectionCommand;
            }
        }

        public void TestDatabaseConnection()
        {
            _databaseService.TestDatabaseConnection();
        }
    }
}
