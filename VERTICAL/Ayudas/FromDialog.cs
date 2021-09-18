using System.Drawing;
using System.Windows.Forms;

namespace VERTICAL.Ayudas
{
    public static class FromDialog
    {
        public static DialogResult PrintDialog(string title, string impresora, string path)
        {
            Form form = new Form();
            Label lblImpresora = new Label();
            Label lblPath = new Label();
            Button buttonYes = new Button();
            Button buttonNot = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            lblImpresora.Text = impresora;
            lblPath.Text = path;

            buttonYes.Text = "Imprimir";
            buttonYes.TextAlign = ContentAlignment.MiddleLeft;
            buttonNot.Text = "Exportar PDF";
            buttonNot.TextAlign = ContentAlignment.MiddleLeft;
            buttonCancel.Text = "Cancel";
            buttonYes.DialogResult = DialogResult.Yes;
            buttonNot.DialogResult = DialogResult.No;
            buttonCancel.DialogResult = DialogResult.Cancel;

            buttonYes.SetBounds(2, 10, 80, 23);
            lblImpresora.SetBounds(82, 15, 372, 23);

            buttonNot.SetBounds(2, 38, 80, 23);
            lblPath.SetBounds(82, 43, 372, 23);

            buttonCancel.SetBounds(280, 66, 80, 23);

            //lblImpresora.AutoSize = true;
            buttonYes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonNot.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { buttonYes, lblImpresora, buttonNot, lblPath, buttonCancel });
            //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            //form.AcceptButton = buttonYes;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();

            return dialogResult;
        }
    }
}
