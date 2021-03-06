﻿using GWMobileApp.Models;
using GWMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GWMobileApp.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
        public TeamViewModel()
        {
            team = GetTeam();
        }

        ObservableCollection<TeamMember> team;
        public ObservableCollection<TeamMember> Team
        {
            get { return team; }
            set
            {
                team = value;
                OnPropertyChanged();
            }
        }

        private TeamMember selectedTeamMember;
        public TeamMember SelectedTeamMember
        {
            get { return selectedTeamMember; }
            set
            {
                selectedTeamMember = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TeamMember> GetTeam()
        {
            return new ObservableCollection<TeamMember>
            {
                new TeamMember { Name = "Christopher Eccleston", Email = "chris@greenworld.co.nz", Phone = "03 312 3456", Mobile = "021 234 5678", DeptRole = "CEO", Image = "Eccleston.jpg", IsPublic = true},
                new TeamMember { Name = "David Tennant", Email = "dave@greenworld.co.nz", Phone = "03 312 3456", Mobile = "022 468 0123", DeptRole = "Sales Manager", Image = "Tennant.jpg", IsPublic = true},
                new TeamMember { Name = "Matt Smith", Email = "matt@greenworld.co.nz", Phone = "03 312 3456", Mobile = "027 098 7654", DeptRole = "Janitor", Image = "Smith.jpg", IsPublic = true},
                new TeamMember { Name = "Peter Capaldi", Email = "peter@greenworld.co.nz", Phone = "03 312 3456", Mobile = "021 468 9365", DeptRole = "Administrator", Image = "Capaldi.jpg", IsPublic = true},
                new TeamMember { Name = "Jodie Whittaker", Email = "jodie@greenworld.co.nz", Phone = "03 312 3456", Mobile = "022 745 3857", DeptRole = "Marketing Manager", Image = "Whittaker.jpg", IsPublic = true}
            };
        }
    }
}
