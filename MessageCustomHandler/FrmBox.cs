using System;
using System.Drawing;
using System.Windows.Forms;

namespace MessageCustomHandler
{
    public partial class FrmBox : Form
    {

        public Result result = new Result
        {
            MainResult = MessageCustomHandler.result.Cancel,
            CustomResult = string.Empty
        };

        internal FrmBox(string Title, string Message, Style style, CButton[] buttons, string MoreDetails = "")
        {

            InitializeComponent();

            this.Text = Title;

            this.DialogResult = DialogResult.Cancel;

            switch(style)
            {
                case Style.Info:
                    PicBadge.Image = new Bitmap(Properties.Resources.custom_info);
                    break;

                case Style.Question:
                    PicBadge.Image = new Bitmap(Properties.Resources.custom_question);
                    break;

                case Style.Warning:
                    PicBadge.Image = new Bitmap(Properties.Resources.custom_exclamation);
                    break;

                case Style.Error:
                    PicBadge.Image = new Bitmap(Properties.Resources.custom_error);
                    break;

                default:
                    break;
            }

            LabelMessage.Text = Message;

            using (Graphics g = CreateGraphics())
            {
                SizeF size = g.MeasureString(Message, LabelMessage.Font, LabelMessage.Width);
                int finalHeight = (int)Math.Ceiling(size.Height) + 5;

                if(LabelMessage.Height < finalHeight)
                {
                    LabelMessage.Height = finalHeight;
                    LabelMessage.TextAlign = ContentAlignment.TopLeft;
                }
                
            }

            this.Height = this.SizeFromClientSize(new Size(this.ClientSize.Width, LabelMessage.Location.Y + LabelMessage.Height + 41)).Height;

            txtMoreDetails.Location = new Point(txtMoreDetails.Location.X, PanelButtons.Location.Y + PanelButtons.Height + 12);

            foreach (CButton newButton in buttons)
            {

                if(PanelButtons.Controls.Count <= 0)
                {
                    newButton.Location = new Point( PanelButtons.Width - newButton.Width - 1, 0 );
                } 
                else
                {
                    newButton.Location = new Point(PanelButtons.Controls[PanelButtons.Controls.Count - 1].Location.X - newButton.Width - 1, 0);
                }

                newButton.Click += delegate
                {
                    this.result.MainResult = newButton.MainResult;
                    
                    if(this.result.MainResult == MessageCustomHandler.result.Custom)
                    {
                        this.result.CustomResult = newButton.CustomResult;
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                PanelButtons.Controls.Add(newButton);

            }

            if(string.IsNullOrWhiteSpace(MoreDetails) == false)
            {
                Button btnMoreDetails = new Button
                {
                    Name = "btnMoreDetails",
                    AutoSize = true,
                    Text = "More Details ⭭⭭⭭"
                };

                btnMoreDetails.Click += btnMoreDetails_Click;

                PanelButtons.Controls.Add(btnMoreDetails);

                txtMoreDetails.Text = MoreDetails;
            }

        }

        private void btnMoreDetails_Click(object sender, EventArgs e)
        {
            Button btnMoreDetails = (Button)sender;

            if (string.IsNullOrWhiteSpace(txtMoreDetails.Text) == true)
            {
                btnMoreDetails.Visible = false;
                return;
            }

            switch (btnMoreDetails.Text)
            {
                case "More Details ⭭⭭⭭":

                    this.Height = this.SizeFromClientSize(new Size(this.ClientSize.Width, txtMoreDetails.Location.Y + txtMoreDetails.Height + txtMoreDetails.Location.X)).Height;

                    btnMoreDetails.Text = "More Details ⭫⭫⭫";

                    txtMoreDetails.Location = new Point(txtMoreDetails.Location.X, PanelButtons.Location.Y - txtMoreDetails.Height - 12);

                    break;

                case "More Details ⭫⭫⭫":

                    this.Height = this.SizeFromClientSize(new Size(this.ClientSize.Width, LabelMessage.Location.Y + LabelMessage.Height + 41)).Height;

                    btnMoreDetails.Text = "More Details ⭭⭭⭭";

                    txtMoreDetails.Location = new Point(txtMoreDetails.Location.X, PanelButtons.Location.Y + PanelButtons.Height + 12);

                    break;

                default:
                    btnMoreDetails.Visible = false;
                    return;
            }
        }
    }
}