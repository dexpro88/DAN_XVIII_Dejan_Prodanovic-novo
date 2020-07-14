using PanisProba.Command;
using PanisProba.Model;
using PanisProba.View;
using PanisService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PanisProba.ViewModel
{
 
    class AddMenagerViewModel:ViewModelBase
    {
        AddMenagerView addMenager;
        IAccessLevelService accessLevelService;
        ISectorService sectorService;
        IEmployeeService employeeService;
        #region Constructor
        public AddMenagerViewModel(AddMenagerView addMenagerOpen)
        {

            addMenager = addMenagerOpen;
            accessLevelService = new AccessLevelService();
            sectorService = new SectorService();
            employeeService = new EmployeeService();

            accessLevelList = accessLevelService.GetAccessLevels();
            sectors = sectorService.GetSectors();
            Menager = new Menager();
        }


        #endregion

        #region Properties
        private List<AccessLevel> accessLevelList;
        public List<AccessLevel> AccessLevelList
        {
            get
            {
                return accessLevelList;
            }
            set
            {
                accessLevelList = value;
                OnPropertyChanged("AccessLevelList");
            }
        }

        private List<Sector> sectors;
        public List<Sector> Sectors
        {
            get
            {
                return sectors;
            }
            set
            {
                sectors = value;
                OnPropertyChanged("Sectors");
            }
        }

        
        private Menager menager;
        public Menager Menager
        {
            get
            {
                return menager;
            }
            set
            {
                menager = value;
                OnPropertyChanged("Menager");
            }
        }
        private AccessLevel accessLevel;
        public AccessLevel AccessLevel
        {
            get
            {
                return accessLevel;
            }
            set
            {
                accessLevel = value;
                OnPropertyChanged("AccessLevel");
            }
        }

        private Sector sector;
        public Sector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }
        


        private DateTime dateOfBirth = DateTime.Now;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; OnPropertyChanged("DateOfBirth"); }
        }

        
        #endregion
        #region Commands

        private ICommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (logoutCommand == null)
                {
                    logoutCommand = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logoutCommand;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                addMenager.Close();             
                loginView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                Menager newMenager = new Menager();
                newMenager.Username = Menager.Username;
                newMenager.Password = Menager.Password;
                employeeService.AddEmployee(newMenager);
                Menager = new Menager();
                MenagerMainView mengerMain = new MenagerMainView();
                mengerMain.Show();
                addMenager.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {

            if (String.IsNullOrEmpty(Menager.Username) ||
                String.IsNullOrEmpty(Menager.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       

       

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                addMenager.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
