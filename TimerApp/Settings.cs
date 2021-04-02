using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp
{
    public class Settings
    {
        public Font font;
        public Color warningFlash;
        public Color background;

        public void SaveSettings(StreamWriter writer)
        {
            if (font!=null)
            {
                writer.WriteLine(font.FontFamily.Name);
                writer.WriteLine(font.Size);
            }
            else
            {
                writer.WriteLine("null");
            }
            if (warningFlash!=null)
            {
                writer.WriteLine(warningFlash.ToArgb());
            }
            else
            {
                writer.WriteLine("null");
            }
            if (background!=null)
            {
                writer.WriteLine(background.ToArgb());
            }
            else
            {
                writer.WriteLine("null");
            }
        }
    }
}
