using System;
using System.Drawing;
using System.Windows.Forms;

public class HelloForm
{
    public static int Main()
    {
        Form f = new Form();
        f.Text = "What would you do?";
        f.Size = new Size(800, 600);

        Label label = new Label();
        label.Location = new Point(50, 20);
        label.Size = new Size(700, 20);
        label.Text = "Trump said: We are deporting Blacks";

        Button btn = new Button();
        btn.Text = "Trve";
        btn.Location = new Point(50, 50);

        Button button = new Button();
        button.Text = "Fake";
        button.Location = new Point(150, 50);

        PictureBox pictureBox = new PictureBox();
        pictureBox.Location = new Point(50, 120);
        pictureBox.Size = new Size(600, 400);
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        btn.Click += (sender, e) =>
        {
            pictureBox.Image = Image.FromFile("C:\\Users\\Yup4uwe\\source\\cp_lab_3\\fell-for-it-again-award-v0-vh5enxtc82xe1.jpg");
            btn.Enabled = false;
            button.Enabled = false;
        };

        button.Click += (sender, e) =>
        {
            pictureBox.Image = Image.FromFile("C:\\Users\\Yup4uwe\\source\\cp_lab_3\\its_over.jpg");
            button.Enabled = false;
            btn.Enabled = false;
        };

        f.Controls.Add(btn);
        f.Controls.Add(button);
        f.Controls.Add(label);
        f.Controls.Add(pictureBox);

        f.ShowDialog();
        return 0;
    }
}