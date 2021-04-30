﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ProjektWinForm.Abfrage;
using ProjektWinForm.Logik;
using ProjektWinForm.Manage_Strecke;
using ProjektWinForm.ManageFahrer;
using ProjektWinForm.Manageteam;
using ProjektWinForm.ManageWettkampf;
using ProjektWinForm.Properties;
using ProjektWinForm.Settings;
using ProjektWinForm.ShowResults;

namespace ProjektWinForm.Application
{
    public partial class Application : Form
    {
        private Logic lk;
        private SettingsLogic se;
        private ManageTeamsForm MTF;
        private SettingsWinForm seWin;
        private ManageFahrerForm MFF;
        private ManageWettkampfForm MWF;
        private AskForWettkampf AFW;
        public int WettkampfID;
        private Abfrage.AbfrageWinForm ABF;
        private ManageStreckeWinForm MSW;

        public Application()
        {
            InitializeComponent();
            lk = new Logic();
            se = new SettingsLogic();
            seWin = new SettingsWinForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (sender != null)
            {
                lk.SetProperties(sender);
                se.setForm1(sender);
            }

            if (!Properties.Settings.Default.StartFile.Equals("none"))
            {
                lk.Load();
            }
        }

        private void manageTeam_btn_Click(object sender, EventArgs e)
        {
            MTF = new ManageTeamsForm(lk);
            MTF.SetProperties(this);
            MTF.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seWin.setProperties(this);
            seWin.ShowDialog();
        }

        private void btn_show_Click_1(object sender, EventArgs e)
        {
            lk.ShowTable();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            lk.Update();
        }

        private void SearchPath_Click(object sender, EventArgs e)
        {
            lk.SelectPath();
        }

        private void openTable_Click(object sender, EventArgs e)
        {
            lk.openTable();
        }

        private void manageFahrer_btn_Click(object sender, EventArgs e)
        {
            MFF = new ManageFahrerForm(lk);
            MFF.setProperties(this);
            MFF.ShowDialog();
        }

        private void manageWettkampf_btn_Click(object sender, EventArgs e)
        {
            MWF = new ManageWettkampfForm(lk);
            MWF.setProperties(this);
            MWF.ShowDialog();
        }

        private void manageStrecke_btn_Click(object sender, EventArgs e)
        {
            MSW = new ManageStreckeWinForm(lk);
            MSW.setProperties(this);
            MSW.ShowDialog();
        }

        private void showResults_btn_Click(object sender, EventArgs e)
        {
            AFW = new AskForWettkampf();
            AFW.setProperties(this);
            AFW.ShowDialog();
            ABF = new AbfrageWinForm();
            ABF.setProperties(this);
            ABF.ShowDialog();
        }
    }
}

