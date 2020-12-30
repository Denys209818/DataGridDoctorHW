using DoctorDataGried.DAL.Classes;
using DoctorDataGried.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGriedDoctorHW
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (Context context = new Context()) 
            {
                if (context.departments.Count() == 0)
                {
                    MessageBox.Show("Натисніть ОК, та зачекайте(йде загрузка даних)....");
                    BogusManager.FillData(context);
                }
                foreach (var item in context.doctors.Include(doc => doc.Department)) 
                {
                    object[] arr = 
                    {
                    item.Id.ToString(),
                    item.FirstName,
                    item.LastName,
                    item.Department.Name
                    };

                    dataGried.Rows.Add(arr);
                }
            }
        }
    }
}
