using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MessageCustomHandler
{
    public enum result
    {
        Cancel = 0,
        OK = 1,
        Yes = 2,
        No = 3,
        Custom = 4,
    }

    public struct Result
    {
        public result MainResult { get; set; }

        public string CustomResult { get; set; }

        public override bool Equals(object obj)
        {
            Result? result = obj as Result?;

            if(result != null)
            {
                return this.Equals(result);
            }

            return false;
        }

        public bool Equals(Result r)
        {

            if (Object.ReferenceEquals(r, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, r))
            {
                return true;
            }

            if (this.GetType() != r.GetType())
            {
                return false;
            }

            return (MainResult == r.MainResult) && (CustomResult == r.CustomResult);

        }

        public override int GetHashCode()
        {
            return 0x00010000 * (int)MainResult;
        }

        public static bool operator ==(Result left, Result right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Result left, Result right)
        {
            return !(left == right);
        }
    }

    public enum Style
    {
        Info = 0,
        Question = 1,
        Warning = 2,
        Error = 3
    }

    public enum Buttons
    {
        Cancel = 0,
        OK = 1,
        CancelOK = 2,
        YesNo = 3,
        YesNoCancel = 4,
        Custom = 5
    }

    internal class CButton : Button
    {

        public result MainResult { get; set; }

        public string CustomResult { get; set; }

        public CButton() { }

    }

    public class CustomButton
    {

        public string Name { get; private set; }

        public string Text { get; private set; }

        public string Result { get; private set; }

        public CustomButton(string Name, string Text, string Result)
        {
            this.Name = Name;
            this.Text = Text;
            this.Result = Result;
        }

        public CustomButton(string Text, string Result)
        {
            this.Name = Text;
            this.Text = Text;
            this.Result = Result;
        }

        public CustomButton(string Text)
        {
            this.Name = Text;
            this.Text = Text;
            this.Result = Text;
        }

    }

    public static class CMBox
    {

        static public Result Show(string message)
        {

            return new Message().New("Info", message, Style.Info, GetButtons(Buttons.OK), string.Empty);

        }

        static public Result Show(object message)
        {

            return new Message().New("Info", message.ToString(), Style.Info, GetButtons(Buttons.OK), string.Empty);

        }

        static public Result Show(string title, string message)
        {

            return new Message().New(title, message, Style.Info, GetButtons(Buttons.OK), string.Empty);

        }

        static public Result Show(string title, string message, Style style, Buttons buttons)
        {

            return new Message().New(title, message, style, GetButtons(buttons), string.Empty);

        }

        static public Result Show(string title, string message, Style style, Buttons buttons, string MoreInfo)
        {

            return new Message().New(title, message, style, GetButtons(buttons), MoreInfo);

        }

        static public Result Show(string title, string message, Style style, Buttons buttons, CustomButton[] customButtons, string MoreInfo)
        {

            List<CButton> finalButtons = new List<CButton>();
            
            if (buttons == Buttons.Custom && customButtons != null && customButtons.Count() > 0)
            {
                foreach (CustomButton newButton in customButtons)
                {
                    finalButtons.Add(new CButton()
                    {
                        Name = newButton.Name,
                        AutoSize = true,
                        Text = newButton.Text,
                        MainResult = result.Custom,
                        CustomResult = newButton.Result
                    });
                }
            }
            else
            {
                finalButtons = GetButtons(buttons).ToList();
            }

            return new Message().New(title, message, style, finalButtons.ToArray(), MoreInfo);

        }

        static public Result Show(string title, string message, Style style, Buttons buttons, string[] customButtons, string MoreInfo)
        {

            List<CButton> finalButtons = new List<CButton>();

            if (buttons == Buttons.Custom && customButtons != null && customButtons.Count() > 0)
            {
                foreach (string newButton in customButtons)
                {
                    finalButtons.Add(new CButton()
                    {
                        Name = newButton,
                        AutoSize = true,
                        Text = newButton,
                        MainResult = result.Custom,
                        CustomResult = newButton
                    });
                }
            }
            else
            {
                finalButtons = GetButtons(buttons).ToList();
            }

            return new Message().New(title, message, style, finalButtons.ToArray(), MoreInfo);

        }

        static private CButton[] GetButtons(Buttons buttonStyle)
        {

            List<CButton> finalButtons = new List<CButton>();

            switch (buttonStyle)
            {
                case Buttons.Cancel:
                    {
                        CButton btnCancel = new CButton
                        {
                            Name = "btnCancel",
                            AutoSize = true,
                            Text = "Cancel",
                            MainResult = result.Cancel
                        };

                        finalButtons.AddRange(new List<CButton> { btnCancel });

                    }
                    break;

                case Buttons.OK:
                    {
                        CButton btnOK = new CButton
                        {
                            Name = "btnOK",
                            AutoSize = true,
                            Text = "OK",
                            MainResult = result.OK
                        };

                        finalButtons.AddRange(new List<CButton> { btnOK });

                    }
                    break;

                case Buttons.CancelOK:
                    {
                        CButton btnCancel = new CButton
                        {
                            Name = "btnCancel",
                            AutoSize = true,
                            Text = "Cancel",
                            MainResult = result.Cancel

                        };

                        CButton btnOK = new CButton
                        {
                            Name = "btnOK",
                            AutoSize = true,
                            Text = "OK",
                            MainResult = result.OK
                        };

                        finalButtons.AddRange(new List<CButton> { btnCancel, btnOK });

                    }
                    break;

                case Buttons.YesNo:
                    {
                        CButton btnNo = new CButton
                        {
                            Name = "btnNo",
                            AutoSize = true,
                            Text = "No",
                            MainResult = result.No
                        };

                        CButton btnYes = new CButton
                        {
                            Name = "btnYes",
                            AutoSize = true,
                            Text = "Yes",
                            MainResult = result.Yes
                        };

                        finalButtons.AddRange(new List<CButton> { btnNo, btnYes });

                    }
                    break;

                case Buttons.YesNoCancel:
                    {

                        CButton btnCancel = new CButton
                        {
                            Name = "btnCancel",
                            AutoSize = true,
                            Text = "Cancel",
                            MainResult = result.Cancel
                        };

                        CButton btnNo = new CButton
                        {
                            Name = "BtnNo",
                            AutoSize = true,
                            Text = "No",
                            MainResult = result.No
                        };

                        CButton btnYes = new CButton
                        {
                            Name = "BtnYes",
                            AutoSize = true,
                            Text = "Yes",
                            MainResult = result.Yes
                        };

                        finalButtons.AddRange(new List<CButton> { btnCancel, btnNo, btnYes });

                    }
                    break;

                default:
                    return null;
            }

            return finalButtons.ToArray();
        }

    }

    internal class Message
    {

        public Result New(string title, string message, Style style, CButton[] buttons, string MoreInfo)
        {

            FrmBox NewInfo = new FrmBox(title, message, style, buttons, MoreInfo);
            
            NewInfo.ShowDialog();

            return NewInfo.result;

        }

    }
}
