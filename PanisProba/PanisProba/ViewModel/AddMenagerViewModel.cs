using PanisProba.Command;
using PanisProba.EntityFrameworkModel;
using PanisProba.Model;
using PanisProba.Service;
using PanisProba.Validation;
using PanisProba.View;
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
         IMenagerService managerService;
        #region Constructor
        public AddMenagerViewModel(AddMenagerView addMenagerOpen)
        {

            addMenager = addMenagerOpen;
            accessLevelService = new AccessLevelService();
            sectorService = new SectorService();
            managerService = new MenagerService();

            accessLevelList = accessLevelService.GetAllAccessLevels();
            sectors = sectorService.GetAllSectors();
            Menager = new tblEmployee();
        }


        #endregion

        #region Properties
        private List<tblAccessLevel> accessLevelList;
        public List<tblAccessLevel> AccessLevelList
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

        private List<tblSector> sectors;
        public List<tblSector> Sectors
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

        
        private tblEmployee menager;
        public tblEmployee Menager
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
        private tblAccessLevel accessLevel;
        public tblAccessLevel AccessLevel
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

        private tblSector sector;
        public tblSector Sector
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
                //tblEmployee newMenager = new tblEmployee();
                //newMenager.Username = Menager.Username;
                //newMenager.Passwd = Menager.Passwd;
                ////employeeService.AddEmployee(newMenager);

                if (!ValidationClass.IsValidEmail(Menager.Email))
                {
                    MessageBox.Show("Email is not valid");
                    return;
                }
                if (!ValidationClass.JMBGisValid(Menager.JMBG))
                {
                    MessageBox.Show("JMBG is not valid.");
                    return;
                }
                if (managerService.GetEmployeeByJMBG(Menager.JMBG)!=null)
                {
                    MessageBox.Show("User with this JMBG already exists");
                    return;
                }
                if (managerService.GetEmployeeByUsername(Menager.Username) != null)
                {
                    MessageBox.Show("User with this username already exists");
                    return;
                }
                if (Menager.Salary<=0)
                {
                    MessageBox.Show("Salary has to be grater than zero.");
                    return;
                }
                Menager.AccessLevelID = AccessLevel.ID;
                Menager.SectorID = Sector.SectorID;
                Menager.DateOfBirth = DateOfBirth;
                managerService.AddMenager(Menager);
                Menager = new tblEmployee();
                MessageBox.Show("You successfully added a manager.");
                LoginView loginMain = new LoginView();
                loginMain.Show();
                addMenager.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {

            if (String.IsNullOrEmpty(Menager.Username) || String.IsNullOrEmpty(Menager.FirstName) ||
                String.IsNullOrEmpty(Menager.LastName) || String.IsNullOrEmpty(Menager.JMBG) ||
                String.IsNullOrEmpty(Menager.AccountNumber) || String.IsNullOrEmpty(Menager.Email) ||
                Sector == null || AccessLevel == null ||
                String.IsNullOrEmpty(Menager.Passwd))
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
