﻿using Short_Story_Network___Practical_Evaluation_Rootcode.Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Views
{
    public partial class uiPosts : Form
    {
        public int userID = 0;
        public uiPosts()
        {
            InitializeComponent();
            Fill_Data(0);
        }
        private void Load_Writers()
        {
           
        }

        private void showAllUsers_Click(object sender, EventArgs e)
        {
           
        }
        private ClientResponse Fill_Data(int userID)
        {
            try
            {
                clsPost clsPostObj = new clsPost();

                var writerList = (List<Post>)clsPostObj.Get_Post_List(userID).ResultObject;
                userList.DataSource = writerList;
                this.userList.Columns["PostId"].Visible = false;
                this.userList.Columns["UserId"].Visible = false;

                return new ClientResponse { Message = "", State = true, ResultObject = true };
            }
            catch (Exception ex)
            {
                return new ClientResponse { ClientException = ex, State = false };
            }
        }

        private void userList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.userList.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                this.userList.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void userList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var userID = this.userList.Rows[e.RowIndex].Cells["Id"].Value;
                var test = 1;
            }
            catch (Exception)
            {

                throw;

            }
        }
