
namespace SADI_Desktop_v1
{
    partial class FrmCliente

    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCliente));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CboTipoTel05 = new System.Windows.Forms.ComboBox();
            this.TxtNumero05 = new System.Windows.Forms.TextBox();
            this.TxtPreTel05 = new System.Windows.Forms.TextBox();
            this.CboTipoTel04 = new System.Windows.Forms.ComboBox();
            this.TxtNumero04 = new System.Windows.Forms.TextBox();
            this.TxtPreTel04 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtContEMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtContApeNom = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboTipoTel03 = new System.Windows.Forms.ComboBox();
            this.TxtNumero03 = new System.Windows.Forms.TextBox();
            this.TxtPreTel03 = new System.Windows.Forms.TextBox();
            this.CboTipoTel02 = new System.Windows.Forms.ComboBox();
            this.TxtNumero02 = new System.Windows.Forms.TextBox();
            this.TxtPreTel02 = new System.Windows.Forms.TextBox();
            this.CboTipoTel01 = new System.Windows.Forms.ComboBox();
            this.TxtNumero01 = new System.Windows.Forms.TextBox();
            this.TxtPreTel01 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtObs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtEMail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtRedSocial = new System.Windows.Forms.TextBox();
            this.TxtCuit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CboCFical = new System.Windows.Forms.ComboBox();
            this.BtnLocalidad = new System.Windows.Forms.Button();
            this.CboLocalidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtRazonSocial = new System.Windows.Forms.TextBox();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 447);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnBuscar);
            this.tabPage1.Controls.Add(this.Grid);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.TxtBuscar);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(721, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(632, 27);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // Grid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grid.Location = new System.Drawing.Point(14, 57);
            this.Grid.Name = "Grid";
            this.Grid.RowTemplate.Height = 25;
            this.Grid.Size = new System.Drawing.Size(693, 348);
            this.Grid.TabIndex = 3;
            this.Grid.DoubleClick += new System.EventHandler(this.GridRespCalib_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Buscar:";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(14, 28);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(612, 23);
            this.TxtBuscar.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.TxtContEMail);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.TxtContApeNom);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.TxtObs);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.TxtEMail);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.TxtRedSocial);
            this.tabPage2.Controls.Add(this.TxtCuit);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.TxtDireccion);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.CboCFical);
            this.tabPage2.Controls.Add(this.BtnLocalidad);
            this.tabPage2.Controls.Add(this.CboLocalidad);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.TxtID);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.BtnGuardar);
            this.tabPage2.Controls.Add(this.BtnEliminar);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.TxtRazonSocial);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(721, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mas Datos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(366, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 15);
            this.label13.TabIndex = 44;
            this.label13.Text = "Contacto: Apellido y Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CboTipoTel05);
            this.groupBox2.Controls.Add(this.TxtNumero05);
            this.groupBox2.Controls.Add(this.TxtPreTel05);
            this.groupBox2.Controls.Add(this.CboTipoTel04);
            this.groupBox2.Controls.Add(this.TxtNumero04);
            this.groupBox2.Controls.Add(this.TxtPreTel04);
            this.groupBox2.Location = new System.Drawing.Point(370, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 95);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contacto: Telefonos";
            // 
            // CboTipoTel05
            // 
            this.CboTipoTel05.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoTel05.FormattingEnabled = true;
            this.CboTipoTel05.Items.AddRange(new object[] {
            "Telefono Fijo",
            "Telefono Celular",
            "Telegram",
            "Whatsapp",
            "Line"});
            this.CboTipoTel05.Location = new System.Drawing.Point(41, 51);
            this.CboTipoTel05.Name = "CboTipoTel05";
            this.CboTipoTel05.Size = new System.Drawing.Size(121, 23);
            this.CboTipoTel05.TabIndex = 28;
            // 
            // TxtNumero05
            // 
            this.TxtNumero05.Location = new System.Drawing.Point(220, 51);
            this.TxtNumero05.MaxLength = 10;
            this.TxtNumero05.Name = "TxtNumero05";
            this.TxtNumero05.Size = new System.Drawing.Size(87, 23);
            this.TxtNumero05.TabIndex = 30;
            this.TxtNumero05.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPreTel05
            // 
            this.TxtPreTel05.Location = new System.Drawing.Point(166, 51);
            this.TxtPreTel05.MaxLength = 5;
            this.TxtPreTel05.Name = "TxtPreTel05";
            this.TxtPreTel05.Size = new System.Drawing.Size(48, 23);
            this.TxtPreTel05.TabIndex = 29;
            this.TxtPreTel05.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CboTipoTel04
            // 
            this.CboTipoTel04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoTel04.FormattingEnabled = true;
            this.CboTipoTel04.Items.AddRange(new object[] {
            "Telefono Fijo",
            "Telefono Celular",
            "Telegram",
            "Whatsapp",
            "Line"});
            this.CboTipoTel04.Location = new System.Drawing.Point(41, 22);
            this.CboTipoTel04.Name = "CboTipoTel04";
            this.CboTipoTel04.Size = new System.Drawing.Size(121, 23);
            this.CboTipoTel04.TabIndex = 25;
            // 
            // TxtNumero04
            // 
            this.TxtNumero04.Location = new System.Drawing.Point(220, 22);
            this.TxtNumero04.MaxLength = 10;
            this.TxtNumero04.Name = "TxtNumero04";
            this.TxtNumero04.Size = new System.Drawing.Size(87, 23);
            this.TxtNumero04.TabIndex = 27;
            this.TxtNumero04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPreTel04
            // 
            this.TxtPreTel04.Location = new System.Drawing.Point(166, 22);
            this.TxtPreTel04.MaxLength = 5;
            this.TxtPreTel04.Name = "TxtPreTel04";
            this.TxtPreTel04.Size = new System.Drawing.Size(48, 23);
            this.TxtPreTel04.TabIndex = 26;
            this.TxtPreTel04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(366, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 15);
            this.label9.TabIndex = 42;
            this.label9.Text = "Contacto: Correo Electronico";
            // 
            // TxtContEMail
            // 
            this.TxtContEMail.Location = new System.Drawing.Point(369, 250);
            this.TxtContEMail.MaxLength = 35;
            this.TxtContEMail.Name = "TxtContEMail";
            this.TxtContEMail.Size = new System.Drawing.Size(345, 23);
            this.TxtContEMail.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(366, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 15);
            this.label8.TabIndex = 40;
            // 
            // TxtContApeNom
            // 
            this.TxtContApeNom.Location = new System.Drawing.Point(370, 206);
            this.TxtContApeNom.MaxLength = 35;
            this.TxtContApeNom.Name = "TxtContApeNom";
            this.TxtContApeNom.Size = new System.Drawing.Size(345, 23);
            this.TxtContApeNom.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboTipoTel03);
            this.groupBox1.Controls.Add(this.TxtNumero03);
            this.groupBox1.Controls.Add(this.TxtPreTel03);
            this.groupBox1.Controls.Add(this.CboTipoTel02);
            this.groupBox1.Controls.Add(this.TxtNumero02);
            this.groupBox1.Controls.Add(this.TxtPreTel02);
            this.groupBox1.Controls.Add(this.CboTipoTel01);
            this.groupBox1.Controls.Add(this.TxtNumero01);
            this.groupBox1.Controls.Add(this.TxtPreTel01);
            this.groupBox1.Location = new System.Drawing.Point(370, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 115);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telefonos";
            // 
            // CboTipoTel03
            // 
            this.CboTipoTel03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoTel03.FormattingEnabled = true;
            this.CboTipoTel03.Items.AddRange(new object[] {
            "Telefono Fijo",
            "Telefono Celular",
            "Telegram",
            "Whatsapp",
            "Line"});
            this.CboTipoTel03.Location = new System.Drawing.Point(41, 80);
            this.CboTipoTel03.Name = "CboTipoTel03";
            this.CboTipoTel03.Size = new System.Drawing.Size(121, 23);
            this.CboTipoTel03.TabIndex = 20;
            // 
            // TxtNumero03
            // 
            this.TxtNumero03.Location = new System.Drawing.Point(220, 80);
            this.TxtNumero03.MaxLength = 10;
            this.TxtNumero03.Name = "TxtNumero03";
            this.TxtNumero03.Size = new System.Drawing.Size(87, 23);
            this.TxtNumero03.TabIndex = 22;
            this.TxtNumero03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPreTel03
            // 
            this.TxtPreTel03.Location = new System.Drawing.Point(166, 80);
            this.TxtPreTel03.MaxLength = 5;
            this.TxtPreTel03.Name = "TxtPreTel03";
            this.TxtPreTel03.Size = new System.Drawing.Size(48, 23);
            this.TxtPreTel03.TabIndex = 21;
            this.TxtPreTel03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CboTipoTel02
            // 
            this.CboTipoTel02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoTel02.FormattingEnabled = true;
            this.CboTipoTel02.Items.AddRange(new object[] {
            "Telefono Fijo",
            "Telefono Celular",
            "Telegram",
            "Whatsapp",
            "Line"});
            this.CboTipoTel02.Location = new System.Drawing.Point(41, 51);
            this.CboTipoTel02.Name = "CboTipoTel02";
            this.CboTipoTel02.Size = new System.Drawing.Size(121, 23);
            this.CboTipoTel02.TabIndex = 17;
            // 
            // TxtNumero02
            // 
            this.TxtNumero02.Location = new System.Drawing.Point(220, 51);
            this.TxtNumero02.MaxLength = 10;
            this.TxtNumero02.Name = "TxtNumero02";
            this.TxtNumero02.Size = new System.Drawing.Size(87, 23);
            this.TxtNumero02.TabIndex = 19;
            this.TxtNumero02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPreTel02
            // 
            this.TxtPreTel02.Location = new System.Drawing.Point(166, 51);
            this.TxtPreTel02.MaxLength = 5;
            this.TxtPreTel02.Name = "TxtPreTel02";
            this.TxtPreTel02.Size = new System.Drawing.Size(48, 23);
            this.TxtPreTel02.TabIndex = 18;
            this.TxtPreTel02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CboTipoTel01
            // 
            this.CboTipoTel01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoTel01.FormattingEnabled = true;
            this.CboTipoTel01.Items.AddRange(new object[] {
            "Telefono Fijo",
            "Telefono Celular",
            "Telegram",
            "Whatsapp",
            "Line"});
            this.CboTipoTel01.Location = new System.Drawing.Point(41, 22);
            this.CboTipoTel01.Name = "CboTipoTel01";
            this.CboTipoTel01.Size = new System.Drawing.Size(121, 23);
            this.CboTipoTel01.TabIndex = 14;
            // 
            // TxtNumero01
            // 
            this.TxtNumero01.Location = new System.Drawing.Point(220, 22);
            this.TxtNumero01.MaxLength = 10;
            this.TxtNumero01.Name = "TxtNumero01";
            this.TxtNumero01.Size = new System.Drawing.Size(87, 23);
            this.TxtNumero01.TabIndex = 16;
            this.TxtNumero01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPreTel01
            // 
            this.TxtPreTel01.Location = new System.Drawing.Point(166, 22);
            this.TxtPreTel01.MaxLength = 5;
            this.TxtPreTel01.Name = "TxtPreTel01";
            this.TxtPreTel01.Size = new System.Drawing.Size(48, 23);
            this.TxtPreTel01.TabIndex = 15;
            this.TxtPreTel01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "Observaciones";
            // 
            // TxtObs
            // 
            this.TxtObs.Location = new System.Drawing.Point(13, 343);
            this.TxtObs.MaxLength = 155;
            this.TxtObs.Multiline = true;
            this.TxtObs.Name = "TxtObs";
            this.TxtObs.Size = new System.Drawing.Size(345, 64);
            this.TxtObs.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Correo Electronico";
            // 
            // TxtEMail
            // 
            this.TxtEMail.Location = new System.Drawing.Point(13, 122);
            this.TxtEMail.MaxLength = 35;
            this.TxtEMail.Name = "TxtEMail";
            this.TxtEMail.Size = new System.Drawing.Size(345, 23);
            this.TxtEMail.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Red Social";
            // 
            // TxtRedSocial
            // 
            this.TxtRedSocial.Location = new System.Drawing.Point(13, 162);
            this.TxtRedSocial.MaxLength = 100;
            this.TxtRedSocial.Name = "TxtRedSocial";
            this.TxtRedSocial.Size = new System.Drawing.Size(345, 23);
            this.TxtRedSocial.TabIndex = 7;
            // 
            // TxtCuit
            // 
            this.TxtCuit.Location = new System.Drawing.Point(15, 251);
            this.TxtCuit.MaxLength = 13;
            this.TxtCuit.Name = "TxtCuit";
            this.TxtCuit.Size = new System.Drawing.Size(345, 23);
            this.TxtCuit.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "CUIT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Direccion";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(370, 30);
            this.TxtDireccion.MaxLength = 40;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(345, 23);
            this.TxtDireccion.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Condicion Fiscal";
            // 
            // CboCFical
            // 
            this.CboCFical.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCFical.FormattingEnabled = true;
            this.CboCFical.Items.AddRange(new object[] {
            "Responsable Inscripto",
            "Responsable No Inscripto",
            "Monotributista",
            "Sin Inscripcion"});
            this.CboCFical.Location = new System.Drawing.Point(15, 206);
            this.CboCFical.Name = "CboCFical";
            this.CboCFical.Size = new System.Drawing.Size(313, 23);
            this.CboCFical.TabIndex = 8;
            // 
            // BtnLocalidad
            // 
            this.BtnLocalidad.Location = new System.Drawing.Point(338, 298);
            this.BtnLocalidad.Name = "BtnLocalidad";
            this.BtnLocalidad.Size = new System.Drawing.Size(21, 23);
            this.BtnLocalidad.TabIndex = 11;
            this.BtnLocalidad.Text = "..";
            this.BtnLocalidad.UseVisualStyleBackColor = true;
            this.BtnLocalidad.Click += new System.EventHandler(this.BtnLocalidad_Click);
            // 
            // CboLocalidad
            // 
            this.CboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboLocalidad.FormattingEnabled = true;
            this.CboLocalidad.Location = new System.Drawing.Point(13, 299);
            this.CboLocalidad.Name = "CboLocalidad";
            this.CboLocalidad.Size = new System.Drawing.Size(313, 23);
            this.CboLocalidad.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Razon Social";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "ID:";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(15, 34);
            this.TxtID.Name = "TxtID";
            this.TxtID.ReadOnly = true;
            this.TxtID.Size = new System.Drawing.Size(108, 23);
            this.TxtID.TabIndex = 11;
            this.TxtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(479, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 26);
            this.button3.TabIndex = 31;
            this.button3.Text = "&Nuevo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(557, 381);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(72, 26);
            this.BtnGuardar.TabIndex = 32;
            this.BtnGuardar.Text = "&Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(635, 381);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(72, 26);
            this.BtnEliminar.TabIndex = 33;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Localidad";
            // 
            // TxtRazonSocial
            // 
            this.TxtRazonSocial.Location = new System.Drawing.Point(13, 78);
            this.TxtRazonSocial.MaxLength = 40;
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            this.TxtRazonSocial.Size = new System.Drawing.Size(345, 23);
            this.TxtRazonSocial.TabIndex = 5;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(651, 465);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(72, 24);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.Text = "&Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 501);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Cliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRazonSocial;
        private System.Windows.Forms.Button BtnLocalidad;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CboLocalidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox CboCFical;
        private System.Windows.Forms.TextBox TxtCuit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtEMail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtRedSocial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtObs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtContApeNom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CboTipoTel03;
        private System.Windows.Forms.TextBox TxtNumero03;
        private System.Windows.Forms.TextBox TxtPreTel03;
        private System.Windows.Forms.ComboBox CboTipoTel02;
        private System.Windows.Forms.TextBox TxtNumero02;
        private System.Windows.Forms.TextBox TxtPreTel02;
        private System.Windows.Forms.ComboBox CboTipoTel01;
        private System.Windows.Forms.TextBox TxtNumero01;
        private System.Windows.Forms.TextBox TxtPreTel01;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CboTipoTel05;
        private System.Windows.Forms.TextBox TxtNumero05;
        private System.Windows.Forms.TextBox TxtPreTel05;
        private System.Windows.Forms.ComboBox CboTipoTel04;
        private System.Windows.Forms.TextBox TxtNumero04;
        private System.Windows.Forms.TextBox TxtPreTel04;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtContEMail;
        private System.Windows.Forms.Label label13;
    }
}

