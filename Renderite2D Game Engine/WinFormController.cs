using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public static class WinFormController
    {
        public static readonly string projectsFolder = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Renderite2D Projects";

        public static BaseForm previouslyOpenForm = null;
        public static BaseForm currentlyOpenForm = null;
    }
}
