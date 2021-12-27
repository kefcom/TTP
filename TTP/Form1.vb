Public Class Form1
    Dim buffer As String = ""
    Dim currentPositionX = 0
    Dim currentPositionY = 7500
    Dim currentPositionY1 = 0
    Dim maxWidth As Integer = 35
    Dim maxHeight As Integer
    Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz1234567890!#@&_: "
    Dim firstBoot1 As Boolean


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim found As Integer
        If sp1.IsOpen = False Then
            sp1.PortName = "COM" & TextBox1.Text
            sp1.Close()
            found = 0
            Do
                Try
                    sp1.Open()
                    found = 1
                Catch ex As Exception
                    TextBox1.Text = TextBox1.Text + 1
                End Try
            Loop Until found = 1 Or TextBox1.Text > 30
            If found = 0 Then
                MsgBox("Comport not found :'( are you sure it's connected?", MsgBoxStyle.Critical, "Fatal error")
            Else
                Button1.Enabled = False
                sndTmr.Enabled = True
            End If
        End If

        'init printer
        maxWidth = (11000 / (txtFontSize.Text * 70)) + 5
        maxHeight = (7500 / (txtFontSize.Text * 70)) + 3
        'MsgBox(maxWidth)
        'MsgBox(maxHeight)

        sndTmr.Interval = txtSpeed.Text
        resetPrinter()

        firstBoot.Enabled = True

    End Sub

    Sub resetPrinter()
        sendText("IN;")
        sendText("SP1;")
        sendText("PU" & currentPositionX & "," & currentPositionY & ";")
        sendText("SI0." & txtFontSize.Text & ",0." & txtFontSize.Text & ";")
        sendText("LB")
        currentPositionX = 0
        currentPositionY1 = 0
        buffer = "Tweets containing #" & txt_hashtag.Text & ": " & vbCrLf
        Application.DoEvents()
        Threading.Thread.Sleep(5000)
        sndTmr.Enabled = True
    End Sub
    Private Sub sndTmr_Tick(sender As Object, e As EventArgs) Handles sndTmr.Tick
        If (buffer.Length > 0) Then
            sendText(buffer.Substring(0, 1))
            If (buffer.Substring(0, 1) = vbCrLf Or buffer.Substring(0, 1) = vbCr) Then
                currentPositionX = 0
                currentPositionY1 = currentPositionY1 + 1
            Else
                currentPositionX = currentPositionX + 1
            End If
            buffer = buffer.Substring(1, buffer.Length - 1)
            Me.Text = currentPositionX & " / " & currentPositionY1 & "              Buffer length:" & buffer.Length
            If currentPositionX = maxWidth Then
                If currentPositionY1 < maxHeight Then
                    currentPositionY1 = currentPositionY1 + 1
                    currentPositionX = 0
                    sendText(vbCr)
                    sendText(vbCrLf)
                Else
                    sndTmr.Enabled = False
                    If MsgBox("Please load new paper!", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        currentPositionX = 0
                        currentPositionY1 = 0
                        resetPrinter()
                    End If
                End If
            End If
        End If
    End Sub

    Sub sendText(theText As String)
        sp1.Write(theText)
        If theText.Substring(theText.Length - 1, 1) = ";" And theText.Length > 1 Then
            log.Text = log.Text & theText & vbCrLf
        Else
            log.Text = log.Text & theText
        End If
        log.SelectionStart = log.Text.Length
        log.ScrollToCaret()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        firstBoot1 = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles getTweets.Tick
        WebBrowser1.Navigate("https://nitter.net/search?f=tweets&q=%23" & txt_hashtag.Text & "&e-nativeretweets=on&e-replies=on&since=&until=&near=")
    End Sub



    Sub parseTweets()
        Dim htdoc As HtmlDocument
        htdoc = WebBrowser1.Document

        Dim coll As New Collection
        For Each elem As HtmlElement In htdoc.All
            If elem.GetAttribute("className").ToLower.Split(" ").Contains("timeline-item") Then
                coll.Add(elem)
            End If
        Next

        If (coll.Count > 0) Then
            For Each elem As HtmlElement In coll
                Dim thisUserName As String = ""
                Dim thisTweetText As String = ""
                For Each child As HtmlElement In elem.All
                    If child.GetAttribute("className").ToLower.Split(" ").Contains("username") Then
                        thisUserName = child.InnerText.ToLower()
                    End If
                    If child.GetAttribute("className").ToLower.Split(" ").Contains("tweet-content") Then
                        thisTweetText = child.InnerText.ToLower()
                    End If
                Next
                If thisUserName <> "" Then
                    Dim toAdd As String
                    toAdd = thisUserName & ":" & thisTweetText.ToLower()
                    toAdd = toAdd.Replace("#" & txt_hashtag.Text.ToLower(), "")
                    toAdd = cleanText(toAdd)

                    If toAdd.Length > maxWidth Then
                        toAdd = toAdd.Substring(0, maxWidth - 6)
                        toAdd = toAdd & "..."
                    End If
                    Dim found As Boolean
                    found = False
                    For Each boxElem As String In ListBox1.Items
                        If boxElem = toAdd Then
                            found = True
                        End If
                    Next
                    If found = False Then
                        ListBox1.Items.Add(toAdd)
                        If firstBoot1 = False Then
                            'only add to buffer after firstboot
                            buffer = buffer & toAdd & vbCrLf
                        End If

                    End If
                End If


            Next
            If (firstBoot1 = True) Then
                firstBoot1 = False
            End If
        End If
    End Sub

    Function cleanText(theText As String)
        For index As Integer = 1 To (theText.Length - 1)
            If alphabet.Contains(theText.Substring(index, 1)) = False Then
                theText = theText.Replace(theText.Substring(index, 1), "°")
            End If
        Next
        theText = theText.Replace("°", "")
        Return theText
    End Function

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If (WebBrowser1.IsBusy = False) Then
            parseTweets()
        End If
    End Sub
    Private Sub firstBoot_Tick(sender As Object, e As EventArgs) Handles firstBoot.Tick
        getTweets.Enabled = True
        firstBoot.Enabled = False
    End Sub
End Class
