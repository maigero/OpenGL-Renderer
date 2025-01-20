using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGL_App.Engine.Componoent
{
    public partial class BasicInformation : UserControl
    {
        GameObject? gameObj = null;
        public BasicInformation()
        {
            InitializeComponent();
        }

        public BasicInformation(GameObject gameObj)
        {
            InitializeComponent();
            this.gameObj = gameObj;
            this.name.Text = gameObj.Text;
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            gameObj.Text = this.name.Text;
        }
    }
}
