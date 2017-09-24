using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hl7.Fhir;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace FHIR_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var endpoint = new Uri("http://spark.furore.com/fhir");
            var client = new FhirClient(endpoint);
            var query = new string[] { "name=peter" };
            var bundle = client.Search("Patient", query);
            button1.Text = "Got " + bundle.Entry.Count() + " records!";
            label3.Text = "";
            foreach (var entry in bundle.Entry)
            {

                Patient p = (Patient)entry.Resource;
                HumanName[] human = p.Name.ToArray();
                string firstname = String.Join(" ",human[0].Given);
                string familyname = String.Join(" ", human[0].Family);
                string comment = String.Join(" ", human[0].FhirComments);
                Identifier[] Id = p.Identifier.ToArray();
                try
                {
                    label3.Text = label3.Text + Id[0].Value + "\r\n";
                }
                catch (Exception ex)
                {
                    label3.Text = label3.Text + "\r\n";
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    label3.Text = "";
        //    var endpoint = new Uri("http://spark.furore.com/patient");
        //    if (textBox2.Text != "")
        //    {
        //        string s = textBox2.Text;
        //        var client = new FhirClient(endpoint);
        //        var query = new string[] { "id = " + s };
        //        var bundle = client.Search("Patient", query);
        //        foreach (var entry in bundle.Entry)
        //        {
        //            Patient p = (Patient)entry.Resource;
        //            label3.Text = label3.Text + p.Id + "\t" + p.Name + "\r\n";
        //        }
        //    }
        //    else if (textBox2.Text == "")
        //        MessageBox.Show("Please enter a patient's name!");
        }
    }
}
