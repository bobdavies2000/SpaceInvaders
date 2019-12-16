<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.PlayerMoveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FireBulletTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AliensMoveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StrikeSpanTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DetectLaserTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ObserveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Player = New System.Windows.Forms.PictureBox()
        Me.Life2 = New System.Windows.Forms.PictureBox()
        Me.Life1 = New System.Windows.Forms.PictureBox()
        Me.Finish = New System.Windows.Forms.Label()
        CType(Me.Player, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Life2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Life1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlayerMoveTimer
        '
        Me.PlayerMoveTimer.Enabled = True
        Me.PlayerMoveTimer.Interval = 10
        '
        'FireBulletTimer
        '
        Me.FireBulletTimer.Enabled = True
        Me.FireBulletTimer.Interval = 10
        '
        'AliensMoveTimer
        '
        Me.AliensMoveTimer.Enabled = True
        Me.AliensMoveTimer.Interval = 10
        '
        'StrikeSpanTimer
        '
        Me.StrikeSpanTimer.Enabled = True
        Me.StrikeSpanTimer.Interval = 1500
        '
        'DetectLaserTimer
        '
        Me.DetectLaserTimer.Enabled = True
        Me.DetectLaserTimer.Interval = 1
        '
        'ObserveTimer
        '
        Me.ObserveTimer.Interval = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(45, 1042)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(81, 29)
        Me.label1.TabIndex = 12
        Me.label1.Text = "Lives:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(1337, 1042)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(110, 29)
        Me.label2.TabIndex = 11
        Me.label2.Text = "Score: 0"
        '
        'Player
        '
        Me.Player.BackColor = System.Drawing.Color.Black
        Me.Player.Image = CType(resources.GetObject("Player.Image"), System.Drawing.Image)
        Me.Player.Location = New System.Drawing.Point(625, 971)
        Me.Player.Name = "Player"
        Me.Player.Size = New System.Drawing.Size(82, 100)
        Me.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player.TabIndex = 13
        Me.Player.TabStop = False
        '
        'Life2
        '
        Me.Life2.BackgroundImage = CType(resources.GetObject("Life2.BackgroundImage"), System.Drawing.Image)
        Me.Life2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Life2.Location = New System.Drawing.Point(217, 1042)
        Me.Life2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Life2.Name = "Life2"
        Me.Life2.Size = New System.Drawing.Size(45, 46)
        Me.Life2.TabIndex = 15
        Me.Life2.TabStop = False
        '
        'Life1
        '
        Me.Life1.BackgroundImage = CType(resources.GetObject("Life1.BackgroundImage"), System.Drawing.Image)
        Me.Life1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Life1.Location = New System.Drawing.Point(163, 1042)
        Me.Life1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Life1.Name = "Life1"
        Me.Life1.Size = New System.Drawing.Size(45, 46)
        Me.Life1.TabIndex = 14
        Me.Life1.TabStop = False
        '
        'Finish
        '
        Me.Finish.AutoSize = True
        Me.Finish.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Finish.ForeColor = System.Drawing.SystemColors.Info
        Me.Finish.Location = New System.Drawing.Point(582, 518)
        Me.Finish.Name = "Finish"
        Me.Finish.Size = New System.Drawing.Size(0, 37)
        Me.Finish.TabIndex = 16
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowText
        Me.ClientSize = New System.Drawing.Size(1628, 1289)
        Me.Controls.Add(Me.Finish)
        Me.Controls.Add(Me.Life2)
        Me.Controls.Add(Me.Life1)
        Me.Controls.Add(Me.Player)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label2)
        Me.Name = "Main"
        Me.Text = "Space Invaders"
        CType(Me.Player, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Life2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Life1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PlayerMoveTimer As Timer
    Friend WithEvents FireBulletTimer As Timer
    Friend WithEvents AliensMoveTimer As Timer
    Friend WithEvents StrikeSpanTimer As Timer
    Friend WithEvents DetectLaserTimer As Timer
    Friend WithEvents ObserveTimer As Timer
    Private WithEvents label1 As Label
    Private WithEvents label2 As Label
    Friend WithEvents Player As PictureBox
    Private WithEvents Life2 As PictureBox
    Private WithEvents Life1 As PictureBox
    Friend WithEvents Finish As Label
End Class
