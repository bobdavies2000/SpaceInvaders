Imports System.Windows.Forms
' https://www.codeproject.com/Articles/5252990/Space-Invaders-in-Csharp-WinForm
Public Class Main
    Dim moveLeft As Boolean
    Dim moveRight As Boolean
    Dim game As Boolean = True
    Dim aliens = New List(Of PictureBox)
    Dim delay = New List(Of PictureBox)
    Dim limit = 730
    Dim enemies As EnemiesClass
    Dim playerScore As Int32
    Dim speed = -1
    Dim aliensLeft = -1
    Dim aliensTop As Int32
    Dim cnt As Int32
    Dim fired As Boolean
    Dim startLocation As Point

    Private Sub PlayerMoveTimer_Tick(sender As Object, e As EventArgs) Handles PlayerMoveTimer.Tick
        If game = False Then Exit Sub
        If moveLeft And Player.Location.X >= 0 Then Player.Left -= 1
        If moveRight And Player.Location.X <= Me.Width - 10 Then Player.Left += 1
    End Sub
    Private Sub StartGame()
        Player.Location = startLocation
        label1.Top = Player.Location.Y
        label2.Top = label1.Top
        Life1.Top = label1.Top
        Life2.Top = label1.Top
        Finish.Text = ""
        game = True
        moveLeft = False
        moveRight = False
        aliensLeft = -1
        aliensTop = 0
        cnt = 0
        playerScore = 0
        aliens.clear()
        delay.clear()
        For Each c In Me.Controls
            If c.name = "Alien" Or c.name = "Bullet" Or c.name = "Laser" Then Me.Controls.Remove(c)
        Next
        enemies = New EnemiesClass(Me)
        For Each c In Me.Controls
            If c.name = "Alien" Then aliens.add(c) Else c.visible = True
        Next
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        startLocation = New Size(Me.Width / 2, Me.Height - 200)
        StartGame()
    End Sub
    Private Sub Beam(a As PictureBox)
        Dim laser = New PictureBox
        laser.Location = New Point(a.Location.X + a.Width / 3, a.Location.Y + 20)
        laser.Size = New Size(5, 20)
        laser.BackgroundImage = My.Resources.laser
        laser.BackgroundImageLayout = ImageLayout.Stretch
        laser.Name = "Laser"
        Me.Controls.Add(laser)
    End Sub
    Private Sub StrikeSpanTimer_Tick(sender As Object, e As EventArgs) Handles StrikeSpanTimer.Tick
        If game = False Then Exit Sub
        Dim r As New Random
        Dim pick As Int32
        If aliens.count > 0 Then
            pick = r.Next(aliens.count)
            Beam(aliens(pick))
        End If
    End Sub
    Private Sub ObserveTimer_Tick(sender As Object, e As EventArgs) Handles ObserveTimer.Tick
        If game = False Then Exit Sub
        ObserveTimer.Stop()
        For Each delayed In delay
            aliens.Remove(delayed)
        Next
        delay.Clear()
    End Sub
    Private Function Touched(a As PictureBox) As Boolean
        Return a.Location.X <= 0 Or a.Location.X >= limit
    End Function
    Private Sub FireBulletTimer_Tick(sender As Object, e As EventArgs) Handles FireBulletTimer.Tick
        If game = False Then Exit Sub
        For Each c In Me.Controls
            If c.name = "Bullet" Then
                Dim bullet = c
                bullet.top -= 5
                If bullet.location.y <= 0 Then Me.Controls.Remove(bullet)
                For Each ct In Me.Controls
                    If ct.name = "Laser" Then
                        Dim laser = ct
                        If bullet.bounds.intersectswith(laser.bounds) Then
                            Me.Controls.Remove(bullet)
                            Me.Controls.Remove(laser)
                            Score()
                        End If
                    End If
                Next
                For Each ctrl In Me.Controls
                    If ctrl.name = "Alien" Then
                        Dim alien = ctrl
                        If bullet.bounds.intersectswith(alien.bounds) And Touched(alien) = False Then
                            Me.Controls.Remove(bullet)
                            Me.Controls.Remove(alien)
                            aliens.remove(alien)
                            playerScore += 5
                            Score()
                            CheckForWinner()
                        ElseIf bullet.bounds.intersectswith(alien.bounds) And Touched(alien) Then
                            Me.Controls.Remove(bullet)
                            Me.Controls.Remove(alien)
                            delay.add(alien)
                            playerScore += 5
                            Score()
                            CheckForWinner()
                        End If
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub Score()
        label2.Text = "Score: " + playerScore.ToString
    End Sub
    Private Sub DetectLaserTimer_Tick(sender As Object, e As EventArgs) Handles DetectLaserTimer.Tick
        If game = False Then Exit Sub
        For Each c In Me.Controls
            If c.name = "Laser" Then
                Dim laser = c
                laser.Top += 5
                If laser.Location.Y >= limit Then Me.Controls.Remove(laser)
                If laser.Bounds.IntersectsWith(Player.Bounds) Then
                    Me.Controls.Remove(laser)
                    LoseLife()
                End If
            End If
        Next
    End Sub
    Private Sub LoseLife()
        Player.Location = startLocation
        For Each c In Me.Controls
            If c.Name.Contains("Life") And c.Visible Then
                c.Visible = False
                Exit Sub
            End If
        Next
        GameOver()
    End Sub
    Private Sub CheckForWinner()
        Dim count As Int32
        For Each c In Me.Controls
            If c.name = "Alien" Then count += 1
        Next
        If count = 0 Then YouWon()
    End Sub
    Private Sub YouWon()
        GameOver()
        Finish.Text = "You Won!" + vbCrLf + "Score: " + playerScore.ToString() + vbCrLf + "Hit Esc to restart the game"
    End Sub
    Private Sub GameOver()
        game = False
        For Each c In Me.Controls
            If c.name = "Finish" Then c.text = "Game Over" + vbCrLf + "Hit Esc to restart" Else c.visible = False
        Next
    End Sub
    Private Sub SetDirection(a As PictureBox)
        If Touched(a) Then
            aliensTop = 1
            aliensLeft = 0
            cnt += 1
            If cnt = a.Height Then
                aliensTop = 0
                aliensLeft = -speed
                ObserveTimer.Start()
            ElseIf cnt = a.Height * 2 Then
                aliensTop = 0
                aliensLeft = speed
                cnt = 0
                ObserveTimer.Start()
            End If
        End If
    End Sub
    Private Sub AliensMoveTimer_Tick(sender As Object, e As EventArgs) Handles AliensMoveTimer.Tick
        If game = False Then Exit Sub
        For Each alien In aliens
            alien.location = New Point(alien.location.x + aliensLeft, alien.location.y + aliensTop)
            SetDirection(alien)
            Collided(alien)
        Next
    End Sub
    Private Sub Collided(a As PictureBox)
        If a.Bounds.IntersectsWith(Player.Bounds) Then GameOver()
    End Sub
    Private Sub Missile()
        Dim bullet = New PictureBox
        bullet.Location = New Point(Player.Location.X + Player.Width / 2, Player.Location.Y - 20)
        bullet.Size = New Size(5, 20)
        bullet.BackgroundImage = My.Resources.bullet
        bullet.BackgroundImageLayout = ImageLayout.Stretch
        bullet.Name = "Bullet"
        Me.Controls.Add(bullet)
    End Sub
    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.A Or e.KeyCode = Keys.Left Then
            moveLeft = True
        ElseIf e.KeyCode = Keys.D Or e.KeyCode = Keys.Right Then
            moveRight = True
        ElseIf e.KeyCode = Keys.Space And game And Not fired Then
            Missile()
            fired = True
        End If
    End Sub
    Private Sub Main_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.A Or e.KeyCode = Keys.Left Then
            moveLeft = False
        ElseIf e.KeyCode = Keys.D Or e.KeyCode = Keys.Right Then
            moveRight = False
        ElseIf e.KeyCode = Keys.Space Then
            fired = False
        End If
        If e.KeyCode = Keys.Escape And game = False Then StartGame()
    End Sub
End Class




Class EnemiesClass
    Dim width As Int32, height As Int32, columns As Int32, rows As Int32, x As Int32, y As Int32, space As Int32
    Public Sub New(p As Form)
        width = 40
        height = 40
        columns = 10
        rows = 5
        space = 10
        x = 150
        y = 0
        CreateSprites(p)
    End Sub
    Private Sub CreateControl(p As Form)
        Dim pb = New PictureBox()
        pb.Location = New Point(x, y)
        pb.Size = New Size(width, height)
        pb.BackgroundImage = My.Resources.invaders
        pb.BackgroundImageLayout = ImageLayout.Stretch
        pb.Name = "Alien"
        p.Controls.Add(pb)
    End Sub
    Private Sub CreateSprites(p As Form)
        For i = 0 To rows - 1
            For j = 0 To columns - 1
                CreateControl(p)
                x += width + space
            Next
            y += height + space
            x = 150
        Next
    End Sub
End Class