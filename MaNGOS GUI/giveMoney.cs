﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaNGOS_GUI.DataAccess;
using MaNGOS_GUI.Resources;

namespace MaNGOS_GUI
{
    public partial class giveMoney : Form
    {
        public giveMoney()
        {
            InitializeComponent();
        }

        private void buttonSendMoney_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textCharacterName.Text))
                {
                    ServerData sData = new ServerData();

                    if (sData.checkCharacterExists(textCharacterName.Text))
                    {
                        string commandString = "send money " + textCharacterName.Text + " " + textSubject.Text + " " + textMessage.Text + " " + textMoney.Text; 
                        ManguiMain.mangosProcess.StandardInput.WriteLine(commandString);

                        ConfigAccess.updateLog(commandString);

                        MessageBox.Show(string.Format(hcStringResources.Global_CommandSuccesful, commandString));
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(hcStringResources.sendMessage_CharacterDoesntExist);
                    }
                }
                else
                {
                    MessageBox.Show(hcStringResources.sendMeassage_EnterCharacter);
                }
            }
            catch
            {
                MessageBox.Show(hcStringResources.Global_CommandError);
            }
               
        }
    }
}
