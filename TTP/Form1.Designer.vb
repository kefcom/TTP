<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.sp1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFontSize = New System.Windows.Forms.TextBox()
        Me.sndTmr = New System.Windows.Forms.Timer(Me.components)
        Me.txtSpeed = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.log = New System.Windows.Forms.TextBox()
        Me.getTweets = New System.Windows.Forms.Timer(Me.components)
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_hashtag = New System.Windows.Forms.TextBox()
        Me.firstBoot = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COM PORT:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(114, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 26)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 180)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(311, 46)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Connect"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Font Size:"
        '
        'txtFontSize
        '
        Me.txtFontSize.Location = New System.Drawing.Point(114, 62)
        Me.txtFontSize.Name = "txtFontSize"
        Me.txtFontSize.Size = New System.Drawing.Size(100, 26)
        Me.txtFontSize.TabIndex = 5
        Me.txtFontSize.Text = "2"
        '
        'sndTmr
        '
        '
        'txtSpeed
        '
        Me.txtSpeed.Location = New System.Drawing.Point(114, 94)
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.Size = New System.Drawing.Size(100, 26)
        Me.txtSpeed.TabIndex = 9
        Me.txtSpeed.Text = "500"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Send Speed:"
        '
        'log
        '
        Me.log.Location = New System.Drawing.Point(16, 249)
        Me.log.Multiline = True
        Me.log.Name = "log"
        Me.log.Size = New System.Drawing.Size(1401, 961)
        Me.log.TabIndex = 10
        '
        'getTweets
        '
        Me.getTweets.Interval = 5000
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(1546, 45)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(570, 426)
        Me.WebBrowser1.TabIndex = 13
        Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(1546, 506)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(1043, 704)
        Me.ListBox1.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "HashTag:"
        '
        'txt_hashtag
        '
        Me.txt_hashtag.Location = New System.Drawing.Point(114, 136)
        Me.txt_hashtag.Name = "txt_hashtag"
        Me.txt_hashtag.Size = New System.Drawing.Size(213, 26)
        Me.txt_hashtag.TabIndex = 17
        Me.txt_hashtag.Text = "dendermonde"
        '
        'firstBoot
        '
        Me.firstBoot.Interval = 10000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2731, 1248)
        Me.Controls.Add(Me.txt_hashtag)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.log)
        Me.Controls.Add(Me.txtSpeed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFontSize)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents sp1 As IO.Ports.SerialPort
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFontSize As TextBox
    Friend WithEvents sndTmr As Timer
    Friend WithEvents txtSpeed As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents log As TextBox
    Friend WithEvents getTweets As Timer
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_hashtag As TextBox
    Friend WithEvents firstBoot As Timer
End Class
