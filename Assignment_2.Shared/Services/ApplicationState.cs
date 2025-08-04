using Assignment_2.Shared.Models;
using Assignment_2.Shared.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Assignment_2.Shared.Services
{
    public class ApplicationState : INotifyPropertyChanged
    {
        private User? _currentUser;
        private List<TaskItem> _taskItems = new List<TaskItem>();
        private ModalState _taskModalState = ModalState.Closed;
        private ModalState _sidebarTaskModalState = ModalState.Closed;
        private ModalState _sidebarAccountModalState = ModalState.Closed;
        private string _month = string.Empty;
        private string _year = string.Empty;
        private DateTime _selectedDayDate = DateTime.Now;
        private DateTime _dummyDate = DateTime.Now;
        private DateTime _currentDate = DateTime.Now;

        // Function to reset values values of ApplicationState upon logging out.
        public void Reset()
        {
            PropertyChanged = null;
            _currentUser = null;
            _taskItems = new List<TaskItem>();
            _taskModalState = _sidebarTaskModalState = _sidebarAccountModalState = ModalState.Closed;
            _month = _year = string.Empty;
            _dummyDate = _currentDate = _selectedDayDate = DateTime.Now;
        }

        // Standard Getters and Setter 
        public User? CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public List<TaskItem> TaskItems
        {
            get
            {
                return _taskItems;
            }
            set
            {
                {
                    _taskItems = value;
                    OnPropertyChanged(nameof(TaskItems));
                }
            }
        }
        public ModalState TaskModalState
        {
            get
            {
                return _taskModalState;
            }
            set
            {
                _taskModalState = value;
                OnPropertyChanged(nameof(TaskModalState));
            }
        }
        public ModalState SidebarTaskModalState
        {
            get
            {
                return _sidebarTaskModalState;
            }
            set
            {
                _sidebarTaskModalState = value;
                OnPropertyChanged(nameof(SidebarTaskModalState));
            }
        }

        public ModalState SidebarAccountModalState
        {
            get
            {
                return _sidebarAccountModalState;
            }
            set
            {
                _sidebarAccountModalState = value;
                OnPropertyChanged(nameof(SidebarAccountModalState));
            }
        }
        public string Month
        {
            get
            {
                _month = Constants.MONTHS[DummyDate.Month - 1];
                return _month;
            }
            set
            {
                _month = value;
                OnPropertyChanged(nameof(Month));
            }
        }
        public string Year
        {
            get
            {
                _year = DummyDate.Year.ToString();
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));

            }
        }
        public DateTime SelectedDayDate
        {
            get
            {
                return _selectedDayDate;
            }
            set
            {
                _selectedDayDate = value;
                OnPropertyChanged(nameof(SelectedDayDate));

            }
        }

        public DateTime DummyDate
        {
            get
            {
                return _dummyDate;
            }
            set
            {
                _dummyDate = value;
                OnPropertyChanged(nameof(DummyDate));
            }
        }
        public DateTime CurrentDate
        {
            get
            {
                _currentDate = DateTime.Now;
                return _currentDate;
            }
            set
            {
                _currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        // ^^^^^

        // Declares an event to notify subscribers when a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Raises the PropertyChanged event to signal a specific property has been updated
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // Two functions to both increment and decrement the dummy date
        public void DecrementDate()
        {
            DummyDate = DummyDate.AddMonths(-1);
        }
        public void IncrementDate()
        {
            DummyDate = DummyDate.AddMonths(1);
        }
        // Function to reset all modal states
        public void ResetModalStates()
        {
            TaskModalState = ModalState.Closed;
            SidebarTaskModalState = ModalState.Closed;
            SidebarAccountModalState = ModalState.Closed;
        }
    }
}
