using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class FormLoader
    {
        public static void LoadForm(Panel panel, Form form) {
            panel.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            panel.Tag = form;
            form.Show();
        }

    }
