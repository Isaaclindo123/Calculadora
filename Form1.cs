using System.Globalization;
using System.Threading;


namespace calculadora
{
    public partial class Form1 : Form
    {
        List<string> historico = new List<string>();

        double valor1 = 0;
        string operacao = "";
        private Button button0;
        private Button button7;
        private Button button8;
        private Button button10;
        private Button button11;
        private Button button12;
        bool novoNumero = false;
        private void Numero_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            if (novoNumero)
            {
                txtVisor.Text = "";
                novoNumero = false;
            }

            txtVisor.Text += botao.Text;
        }
        private void Operacao_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            if (txtVisor.Text == "") return;

            valor1 = double.Parse(txtVisor.Text);
            operacao = botao.Text;
            novoNumero = true;
        }
        private void btnIgual_Click(object sender, EventArgs e)
        {

            if (txtVisor.Text == "") return;

            double valor2 = double.Parse(txtVisor.Text);
            double resultado = 0;
            


            switch (operacao)
            {
                case "+":
                    resultado = valor1 + valor2;
                    break;
                case "-":
                    resultado = valor1 - valor2;
                    break;
                case "*":
                    resultado = valor1 * valor2;
                    break;
                case "/":
                    if (valor2 == 0)
                    {
                        MessageBox.Show("Divisão por zero");
                        return;
                    }
                    resultado = valor1 / valor2;
                    break;
            }

            historico.Add($"{valor1} {operacao} {valor2} = {resultado}");


            txtVisor.Text = resultado.ToString();
            novoNumero = true;
        }
        private void btnAC_Click(object sender, EventArgs e)
        {
            txtVisor.Text = "";
            valor1 = 0;
            operacao = "";
            novoNumero = false;
        }
        private void btnHistorico_Click(object sender, EventArgs e)
        {
            string texto = "";

            foreach (string item in historico)
                texto += item + "\n";

            MessageBox.Show(texto == "" ? "Sem histórico" : texto, "Histórico");
        }
        private void OperacaoPorTecla(string op)
        {
            if (txtVisor.Text == "") return;

            valor1 = double.Parse(txtVisor.Text);
            operacao = op;
            novoNumero = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                txtVisor.Text += (e.KeyCode - Keys.D0).ToString();

            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                txtVisor.Text += (e.KeyCode - Keys.NumPad0).ToString();

            if (e.KeyCode == Keys.Add) OperacaoPorTecla("+");
            if (e.KeyCode == Keys.Subtract) OperacaoPorTecla("-");
            if (e.KeyCode == Keys.Multiply) OperacaoPorTecla("*");
            if (e.KeyCode == Keys.Divide) OperacaoPorTecla("/");

            if (e.KeyCode == Keys.Enter) btnIgual_Click(null, null);
            if (e.KeyCode == Keys.Back && txtVisor.Text.Length > 0)
                txtVisor.Text = txtVisor.Text.Substring(0, txtVisor.Text.Length - 1);
        }
        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text == "") return;

            double valor = double.Parse(txtVisor.Text);
            valor = valor / 100;
            txtVisor.Text = valor.ToString();
            novoNumero = true;
        }
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (!txtVisor.Text.Contains(","))
            {
                if (txtVisor.Text == "")
                    txtVisor.Text = "0,";
                else
                    txtVisor.Text += ",";
            }
        }



        public Form1()
        {
            InitializeComponent();

            System.Threading.Thread.CurrentThread.CurrentCulture =
    new System.Globalization.CultureInfo("pt-BR");


            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            
        }

        private TextBox txtVisor;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtVisor = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button9 = new Button();
            buttonSoma = new Button();
            buttonIgual = new Button();
            buttonSub = new Button();
            buttonAC = new Button();
            buttonMult = new Button();
            buttonDiv = new Button();
            button0 = new Button();
            button7 = new Button();
            button8 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            SuspendLayout();
            // 
            // txtVisor
            // 
            txtVisor.Font = new Font("Segoe UI", 20F);
            txtVisor.Location = new Point(166, 42);
            txtVisor.Multiline = true;
            txtVisor.Name = "txtVisor";
            txtVisor.ReadOnly = true;
            txtVisor.Size = new Size(637, 132);
            txtVisor.TabIndex = 0;
            txtVisor.TextChanged += txtVisor_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(214, 202);
            button1.Name = "button1";
            button1.Size = new Size(92, 85);
            button1.TabIndex = 2;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Numero_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(370, 202);
            button2.Name = "button2";
            button2.Size = new Size(92, 85);
            button2.TabIndex = 3;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Numero_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(514, 202);
            button3.Name = "button3";
            button3.Size = new Size(92, 85);
            button3.TabIndex = 4;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Numero_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F);
            button4.Location = new Point(642, 202);
            button4.Name = "button4";
            button4.Size = new Size(92, 85);
            button4.TabIndex = 5;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Numero_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(214, 330);
            button5.Name = "button5";
            button5.Size = new Size(92, 85);
            button5.TabIndex = 6;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Numero_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 12F);
            button6.Location = new Point(370, 330);
            button6.Name = "button6";
            button6.Size = new Size(92, 85);
            button6.TabIndex = 7;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Numero_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 12F);
            button9.Location = new Point(370, 458);
            button9.Name = "button9";
            button9.Size = new Size(92, 85);
            button9.TabIndex = 10;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Numero_Click;
            // 
            // buttonSoma
            // 
            buttonSoma.Font = new Font("Segoe UI", 12F);
            buttonSoma.Location = new Point(821, 274);
            buttonSoma.Name = "buttonSoma";
            buttonSoma.Size = new Size(92, 121);
            buttonSoma.TabIndex = 11;
            buttonSoma.Text = "+";
            buttonSoma.UseVisualStyleBackColor = true;
            buttonSoma.Click += Operacao_Click;
            // 
            // buttonIgual
            // 
            buttonIgual.Font = new Font("Segoe UI", 12F);
            buttonIgual.Location = new Point(821, 27);
            buttonIgual.Name = "buttonIgual";
            buttonIgual.Size = new Size(92, 199);
            buttonIgual.TabIndex = 12;
            buttonIgual.Text = "=";
            buttonIgual.UseVisualStyleBackColor = true;
            buttonIgual.Click += btnIgual_Click;
            // 
            // buttonSub
            // 
            buttonSub.Font = new Font("Segoe UI", 12F);
            buttonSub.Location = new Point(821, 430);
            buttonSub.Name = "buttonSub";
            buttonSub.Size = new Size(92, 113);
            buttonSub.TabIndex = 13;
            buttonSub.Text = "-";
            buttonSub.UseVisualStyleBackColor = true;
            buttonSub.Click += Operacao_Click;
            // 
            // buttonAC
            // 
            buttonAC.Font = new Font("Segoe UI", 12F);
            buttonAC.Location = new Point(31, 27);
            buttonAC.Name = "buttonAC";
            buttonAC.Size = new Size(92, 199);
            buttonAC.TabIndex = 14;
            buttonAC.Text = "AC";
            buttonAC.UseVisualStyleBackColor = true;
            buttonAC.Click += btnAC_Click;
            // 
            // buttonMult
            // 
            buttonMult.Font = new Font("Segoe UI", 12F);
            buttonMult.Location = new Point(31, 274);
            buttonMult.Name = "buttonMult";
            buttonMult.Size = new Size(92, 121);
            buttonMult.TabIndex = 15;
            buttonMult.Text = "*";
            buttonMult.UseVisualStyleBackColor = true;
            buttonMult.Click += Operacao_Click;
            // 
            // buttonDiv
            // 
            buttonDiv.Font = new Font("Segoe UI", 12F);
            buttonDiv.Location = new Point(31, 430);
            buttonDiv.Name = "buttonDiv";
            buttonDiv.Size = new Size(92, 113);
            buttonDiv.TabIndex = 16;
            buttonDiv.Text = "/";
            buttonDiv.UseVisualStyleBackColor = true;
            buttonDiv.Click += Operacao_Click;
            // 
            // button0
            // 
            button0.Font = new Font("Segoe UI", 12F);
            button0.Location = new Point(514, 458);
            button0.Name = "button0";
            button0.Size = new Size(92, 85);
            button0.TabIndex = 1;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += Numero_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 12F);
            button7.Location = new Point(514, 330);
            button7.Name = "button7";
            button7.Size = new Size(92, 85);
            button7.TabIndex = 8;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Numero_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 12F);
            button8.Location = new Point(642, 330);
            button8.Name = "button8";
            button8.Size = new Size(92, 85);
            button8.TabIndex = 9;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Numero_Click;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 12F);
            button10.Location = new Point(360, 2);
            button10.Name = "button10";
            button10.Size = new Size(246, 34);
            button10.TabIndex = 17;
            button10.Text = "Histórico";
            button10.UseVisualStyleBackColor = true;
            button10.Click += btnHistorico_Click;
            // 
            // button11
            // 
            button11.Font = new Font("Segoe UI", 12F);
            button11.Location = new Point(214, 458);
            button11.Name = "button11";
            button11.Size = new Size(92, 85);
            button11.TabIndex = 18;
            button11.Text = "%";
            button11.UseVisualStyleBackColor = true;
            button11.Click += btnPorcentagem_Click;
            // 
            // button12
            // 
            button12.Font = new Font("Segoe UI", 12F);
            button12.Location = new Point(642, 458);
            button12.Name = "button12";
            button12.Size = new Size(92, 85);
            button12.TabIndex = 19;
            button12.Text = ",";
            button12.UseVisualStyleBackColor = true;
            button12.Click += btnVirgula_Click;
            // 
            // Form1
            // 
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(939, 555);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(buttonDiv);
            Controls.Add(buttonMult);
            Controls.Add(buttonAC);
            Controls.Add(buttonSub);
            Controls.Add(buttonIgual);
            Controls.Add(buttonSoma);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button0);
            Controls.Add(txtVisor);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Calculadora Isacosa";
            ResumeLayout(false);
            PerformLayout();

        }
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button9;
        private Button buttonSoma;
        private Button buttonIgual;
        private Button buttonSub;
        private Button buttonAC;
        private Button buttonMult;
        private Button buttonDiv;

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void buttonSoma_Click(object sender, EventArgs e)
        {

        }

        private void txtVisor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
