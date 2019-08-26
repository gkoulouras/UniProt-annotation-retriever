Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Xml

Public Class Form1

    Dim filePath As String
    Dim directoryPath As String
    Dim stopClickPressed As Boolean = False
    'Dim currentdate = Date.Now.ToString("ddMMMyyyy")

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub SelectFileBtn_Click(sender As Object, e As EventArgs) Handles SelectFileBtn.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            filePath = OpenFileDialog1.FileName
            directoryPath = Path.GetDirectoryName(filePath)
            Try
                FilePathTxtBox.Text = filePath
            Catch ex As Exception
                MessageBox.Show("The upload process was unsuccessful. Please try again", "Critical Error")
            End Try
        End If
    End Sub

    Public Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        Dim proteinIDs As New DataTable
        Dim proteinAnnot As New DataTable
        LogTxtBox.Clear()

        If filePath <> "" Then
            If LocationChckBox.Checked = False And TopologyChckBox.Checked = False And MolProcChckBox.Checked = False Then
                MessageBox.Show("Please select at least one feature", "Warning message")
            Else
                Try
                    proteinIDs.Columns.Add("protID", Type.GetType("System.String"))

                    proteinAnnot.Columns.Add("uniprotID", Type.GetType("System.String"))
                    proteinAnnot.Columns.Add("location", Type.GetType("System.String"))
                    proteinAnnot.Columns.Add("topology", Type.GetType("System.String"))
                    proteinAnnot.Columns.Add("molecule_processing", Type.GetType("System.String"))

                    Dim sr As New IO.StreamReader(filePath)

                    Dim s As String = String.Empty
                    Do While Not sr.EndOfStream
                        s = sr.ReadLine
                        Dim protID As DataRow = proteinIDs.NewRow()
                        protID("protID") = s
                        proteinIDs.Rows.Add(protID)
                    Loop

                    Dim totalCounter As Integer = proteinIDs.Rows.Count
                    Dim iter As Integer = 0
                    If totalCounter > 0 Then
                        stopClickPressed = False
                        Do While ((stopClickPressed = False) And (iter < totalCounter))

                            Application.DoEvents()
                            LogTxtBox.AppendText("The record " + proteinIDs.Rows(iter).Item(0).ToString + " is currently processed" + " (" + (iter + 1).ToString + "  out of " + (totalCounter).ToString + ")" + vbNewLine)

                            Dim proteinID As String = proteinIDs.Rows(iter).Item(0)
                            Dim type As String = String.Empty
                            Dim type2 As String = String.Empty
                            Dim location As String = String.Empty
                            Dim topology As String = String.Empty
                            Dim mol_processing As String = String.Empty

                            Try


                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                                Dim request As String = "https://www.uniprot.org/uniprot/" & proteinID & ".xml"
                                Dim doc As New XmlDocument
                                doc.Load(request)

                                location = String.Empty
                                topology = String.Empty
                                mol_processing = String.Empty

                                For Each entry As XmlElement In doc.GetElementsByTagName("entry")
                                    For Each feature As XmlElement In entry.GetElementsByTagName("comment")

                                        type = GetAttibuteValue(feature, "type")

                                        If type = "subcellular location" Then

                                            For Each loc As XmlElement In feature.GetElementsByTagName("location")
                                                location = location & ";" & loc.InnerText
                                            Next

                                            For Each top As XmlElement In feature.GetElementsByTagName("topology")
                                                topology = topology & ";" & top.InnerText
                                            Next

                                        End If
                                    Next

                                    If Len(location) > 0 Then
                                        location = location.Substring(1, Len(location) - 1)
                                        Dim locationlist As New List(Of String)(location.Split(";"c))
                                        locationlist = locationlist.Distinct().ToList()
                                        locationlist.Sort()
                                        location = String.Join(" ; ", locationlist)
                                    End If
                                    If Len(topology) > 0 Then
                                        topology = topology.Substring(1, Len(topology) - 1)
                                        Dim topologylist As New List(Of String)(topology.Split(";"c))
                                        topologylist = topologylist.Distinct().ToList()
                                        topologylist.Sort()
                                        topology = String.Join(" ; ", topologylist)
                                    End If

                                    For Each feature2 As XmlElement In entry.GetElementsByTagName("feature")
                                        type2 = GetAttibuteValue(feature2, "type")

                                        If type2 = "initiator methionine" Or type2 = "signal peptide" Or type2 = "transit peptide" Or type2 = "propeptide" Or type2 = "chain" Or type2 = "peptide" Then
                                            mol_processing = mol_processing & ";" & type2
                                        End If

                                    Next
                                    If Len(mol_processing) > 0 Then
                                        mol_processing = mol_processing.Substring(1, Len(mol_processing) - 1)
                                        Dim mol_processinglist As New List(Of String)(mol_processing.Split(";"c))
                                        mol_processinglist = mol_processinglist.Distinct().ToList()
                                        mol_processinglist.Sort()
                                        mol_processing = String.Join(" ; ", mol_processinglist)
                                    End If

                                Next

                                proteinAnnot.Rows.Add(proteinID, location, topology, mol_processing)
                                iter += 1

                            Catch ex As Exception
                                ErrorLogTxtBox.AppendText("The following error occured while processing the " & proteinID & ": " & ex.Message & vbNewLine)
                                iter += 1
                            End Try

                        Loop

                        If stopClickPressed = False Then
                            Dim file As System.IO.StreamWriter
                            Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
                            If proteinAnnot.Rows.Count > 0 Then
                                file = My.Computer.FileSystem.OpenTextFileWriter(directoryPath + "\proteinAnnotations.txt", False, utf8WithoutBom)
                                Dim headerLine1 As String = String.Empty
                                Dim headerLine2 As String = String.Empty
                                Dim mainTxt As String = String.Empty

                                headerLine1 = "UniprotID"
                                If LocationChckBox.Checked = True Then
                                    headerLine1 &= "" + vbTab + "Location"
                                End If
                                If TopologyChckBox.Checked = True Then
                                    headerLine1 &= "" + vbTab + "Topology"
                                End If
                                If MolProcChckBox.Checked = True Then
                                    headerLine1 &= "" + vbTab + "Molecule processing"
                                End If
                                'file.WriteLine("UniprotID" + vbTab + "Location" + vbTab + "Topology" + vbTab + "Molecule processing")
                                file.WriteLine(headerLine1)

                                headerLine2 = "#!{Type}"
                                If LocationChckBox.Checked = True Then
                                    headerLine2 = headerLine2 & "" + vbTab + "Categorical"
                                End If
                                If TopologyChckBox.Checked = True Then
                                    headerLine2 = headerLine2 & "" + vbTab + "Categorical"
                                End If
                                If MolProcChckBox.Checked = True Then
                                    headerLine2 = headerLine2 & "" + vbTab + "Categorical"
                                End If
                                'file.WriteLine("#!{Type}" + vbTab + "Categorical" + vbTab + "Categorical" + vbTab + "Categorical")
                                file.WriteLine(headerLine2)

                                For i As Integer = 0 To proteinAnnot.Rows.Count - 1
                                    mainTxt = proteinAnnot.Rows(i).Item("uniprotID")
                                    If LocationChckBox.Checked = True Then
                                        mainTxt = mainTxt + vbTab + proteinAnnot.Rows(i).Item("location")
                                    End If
                                    If TopologyChckBox.Checked = True Then
                                        mainTxt = mainTxt + vbTab + proteinAnnot.Rows(i).Item("topology")
                                    End If
                                    If MolProcChckBox.Checked = True Then
                                        mainTxt = mainTxt + vbTab + proteinAnnot.Rows(i).Item("molecule_processing")
                                    End If
                                    'file.WriteLine(proteinAnnot.Rows(i).Item("uniprotID") + vbTab + proteinAnnot.Rows(i).Item("location") + vbTab + proteinAnnot.Rows(i).Item("topology") + vbTab + proteinAnnot.Rows(i).Item("molecule_processing"))
                                    file.WriteLine(mainTxt)
                                Next
                                file.Close()

                                Dim directorySelected As DirectoryInfo = New DirectoryInfo(directoryPath)
                                Compress(directorySelected, directoryPath)

                                LogTxtBox.AppendText(vbNewLine + "The annotation file has been created successfully in the following directory: " + vbNewLine)
                                LogTxtBox.AppendText(directoryPath + vbNewLine)
                                LogTxtBox.AppendText(vbNewLine + vbNewLine + "The application terminated successfully")
                            End If
                        Else
                            LogTxtBox.AppendText(vbNewLine + vbNewLine + "The application forcely stopped by the user" + vbNewLine)
                        End If
                    Else
                        MessageBox.Show("An error occured while reading the list of proteins. Please check that the file contains a list of UniProt IDs only.", "Warning message")
                    End If

                Catch ex As Exception
                    ErrorLogTxtBox.AppendText(vbNewLine + "An unexpected error occured. The application stopped." + vbNewLine)
                    MessageBox.Show(ex.Message, "Critical error")
                End Try
            End If
        Else
            MessageBox.Show("Please select a file that contains a list of UniProt IDs", "Warning message")
        End If
    End Sub

    Public Sub Compress(ByVal directorySelected As DirectoryInfo, ByVal path2export As String)
        Dim success_execution As Boolean = False
        For Each fileToCompress As FileInfo In directorySelected.GetFiles()
            If (fileToCompress.Name = "proteinAnnotations.txt") Then
                Using originalFileStream As FileStream = fileToCompress.OpenRead()
                    Try
                        Using compressedFileStream As FileStream = File.Create(fileToCompress.FullName & ".gz")

                            Using compressionStream As GZipStream = New GZipStream(compressedFileStream, CompressionMode.Compress)
                                originalFileStream.CopyTo(compressionStream)
                            End Using
                        End Using

                        Dim info As FileInfo = New FileInfo(path2export & Path.DirectorySeparatorChar & fileToCompress.Name & ".gz")
                        success_execution = True
                    Catch ex As Exception
                        success_execution = False
                    End Try
                End Using
                If success_execution Then
                    My.Computer.FileSystem.DeleteFile(path2export & Path.DirectorySeparatorChar & fileToCompress.Name)
                End If
            End If
        Next
    End Sub

    Private Function GetAttibuteValue(ByVal node As XmlNode, ByVal attibutename As String) As String
        Dim ret As String = String.Empty
        If node IsNot Nothing AndAlso node.Attributes IsNot Nothing Then
            Dim attrib As XmlNode = node.Attributes.GetNamedItem(attibutename)
            If attrib IsNot Nothing Then
                ret = attrib.Value
            End If
        End If
        Return ret
    End Function

    Private Sub StopBtn_Click(sender As Object, e As EventArgs) Handles StopBtn.Click
        stopClickPressed = True
        filePath = ""
        directoryPath = ""
        FilePathTxtBox.Text = ""
        MessageBox.Show("The process has stopped successfully", "Information message")
    End Sub

End Class
