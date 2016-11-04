Option Explicit On
Option Strict On
Option Infer On
Option Compare Text

Imports System.IO
Module TicTacToeAnalyzer

    Sub Main()
        Const INPUT_PATH As String = "C:\Temp\tictactoe.txt"
        Const OUTPUT_PATH As String = "C:\Temp\tictactoeResults.txt"
        Dim rawGameData As String()
        rawGameData = GetInput(INPUT_PATH)
        Dim gameResult As String
        Dim resultData As String()
        ReDim resultData(rawGameData.Length - 1)
        Dim moveData As String
        For i As Integer = 1 To rawGameData.Length - 1
            moveData = rawGameData(i)
            gameResult = PlayGame(moveData, i)
            resultData(i) = gameResult
        Next
        gameResult = resultData(1)
        gameResult = String.Join(Environment.NewLine, resultData).Trim()
        WriteOutput(OUTPUT_PATH, gameResult)
    End Sub
    Private Function PlayGame(ByVal moveData As String, ByVal gameNumber As Integer) As String
        Const DELIMITER As String = " "
        Dim moveArray As Integer()
        moveArray = ConvertStringsToIntegers(moveData, DELIMITER)
        Dim boardArray As Integer()
        ReDim boardArray(9)
        Dim gameWinner As String
        Dim isWon As Boolean
        Dim move As Integer
        Dim square As Integer
        Dim player As Integer
        For iterator As Integer = 0 To boardArray.Length
            move = iterator + 1
            square = moveArray(iterator)
            Select Case move
                Case 1, 3, 5, 7, 9
                    player = 1
                    boardArray(square) = 1
                Case 2, 4, 6, 8
                    player = 2
                    boardArray(square) = 2
            End Select
            If move > 4 Then isWon = CheckWin(boardArray, square)
            If isWon Then
                gameWinner = "Game #" & gameNumber & " is won by Player " & player & " on move #" & move & " in square #" & square & "."
                Return gameWinner
            End If
        Next
        Return "Game #" & gameNumber & " is a draw."
    End Function
    Private Function CheckWin(ByVal boardarray As Integer(), ByVal square As Integer) As Boolean
        Dim isWin As Boolean
        isWin = False
        Select Case square
            Case 1
                If boardarray(1) = boardarray(2) And boardarray(1) = boardarray(3) Then isWin = True
                If boardarray(1) = boardarray(4) And boardarray(1) = boardarray(7) Then isWin = True
                If boardarray(1) = boardarray(5) And boardarray(1) = boardarray(9) Then isWin = True
            Case 2
                If boardarray(2) = boardarray(1) And boardarray(2) = boardarray(3) Then isWin = True
                If boardarray(2) = boardarray(5) And boardarray(2) = boardarray(8) Then isWin = True
            Case 3
                If boardarray(3) = boardarray(2) And boardarray(3) = boardarray(1) Then isWin = True
                If boardarray(3) = boardarray(6) And boardarray(3) = boardarray(9) Then isWin = True
                If boardarray(3) = boardarray(5) And boardarray(3) = boardarray(7) Then isWin = True
            Case 4
                If boardarray(4) = boardarray(1) And boardarray(4) = boardarray(7) Then isWin = True
                If boardarray(4) = boardarray(5) And boardarray(4) = boardarray(6) Then isWin = True
            Case 5
                If boardarray(5) = boardarray(1) And boardarray(5) = boardarray(9) Then isWin = True
                If boardarray(5) = boardarray(2) And boardarray(5) = boardarray(8) Then isWin = True
                If boardarray(5) = boardarray(3) And boardarray(5) = boardarray(7) Then isWin = True
                If boardarray(5) = boardarray(4) And boardarray(5) = boardarray(6) Then isWin = True
            Case 6
                If boardarray(6) = boardarray(3) And boardarray(6) = boardarray(9) Then isWin = True
                If boardarray(6) = boardarray(5) And boardarray(6) = boardarray(4) Then isWin = True
            Case 7
                If boardarray(7) = boardarray(8) And boardarray(7) = boardarray(9) Then isWin = True
                If boardarray(7) = boardarray(1) And boardarray(7) = boardarray(4) Then isWin = True
                If boardarray(7) = boardarray(3) And boardarray(7) = boardarray(5) Then isWin = True
            Case 8
                If boardarray(8) = boardarray(2) And boardarray(8) = boardarray(5) Then isWin = True
                If boardarray(8) = boardarray(7) And boardarray(8) = boardarray(9) Then isWin = True
            Case 9
                If boardarray(9) = boardarray(1) And boardarray(9) = boardarray(5) Then isWin = True
                If boardarray(9) = boardarray(3) And boardarray(9) = boardarray(6) Then isWin = True
                If boardarray(9) = boardarray(7) And boardarray(9) = boardarray(8) Then isWin = True
        End Select
        Return isWin
    End Function
    Private Function GetInput(ByVal inputPath As String) As String()
        Return File.ReadAllLines(inputPath)
    End Function
    Private Function ConvertStringsToIntegers(ByVal moveData As String, ByVal DELIMITER As String) As Integer()
        Dim arrayOfStrings As String() = moveData.Split(New String() {DELIMITER}, StringSplitOptions.None)
        Return Array.ConvertAll(arrayOfStrings, Function(str) Integer.Parse(str))
    End Function
    Private Sub WriteOutput(ByVal outputPath As String, ByVal gameResult As String)
        Using fileAuthor As New StreamWriter(outputPath)
            fileAuthor.WriteLine(gameResult)
        End Using
    End Sub
End Module
