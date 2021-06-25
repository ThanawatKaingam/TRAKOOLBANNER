' 'url' is the url you want to download
'url = "https://"

' 'path' is the location where you want to save the file
'path = "C:\temps\_test.txt"

Set objXMLHTTP = CreateObject("MSXML2.XMLHTTP")
objXMLHTTP.open "GET", url, false
objXMLHTTP.send()

If objXMLHTTP.Status = 200 Then
  Set objADOStream = CreateObject("ADODB.Stream")
  objADOStream.Open
  objADOStream.Type = 1 'adTypeBinary
  objADOStream.Write objXMLHTTP.ResponseBody
  objADOStream.Position = 0    'Set the stream position to the start
  Set objFSO = Createobject("Scripting.FileSystemObject")
  If objFSO.Fileexists(path) Then objFSO.DeleteFile path
  Set objFSO = Nothing
  objADOStream.SaveToFile path
  objADOStream.Close
  Set objADOStream = Nothing
End if

Set objXMLHTTP = Nothing