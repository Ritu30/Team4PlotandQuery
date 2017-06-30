<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="TestFileUpload.FileUploadTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript">
        
        $(document).ready(function () {

            $('#btnUploadFile').on('click', function () {

                var file_list = this.target.files;

                for (var i = 0, file; file = file_list[i]; i++) {
                    var sFileName = file.name;
                    var sFileExtension = sFileName.split('.')[sFileName.split('.').length - 1].toLowerCase();
                    var iFileSize = file.size;
                    var iConvert = (file.size / 10485760).toFixed(2);

                    if (!(sFileExtension === "json")) {
                        txt = "File type : " + sFileExtension + "\n\n";
                        //txt += "Size: " + iConvert + " MB \n\n";
                        txt += "Please make sure your file is json format and less than 10 MB.\n\n";
                        alert(txt);
                    }
                }

                var data = new FormData();

                var files = $("#fileUpload").get(0).files;

                // Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "/api/fileupload/uploadfile",
                    contentType: false,
                    processData: false,
                    data: data
                });

                ajaxRequest.done(function (responseData, textStatus) {
                    if (textStatus == 'success') {
                        if (responseData != null) {
                            if (responseData.Key) {
                                alert(responseData.Value);
                                $("#fileUpload").val('');
                            } else {
                                alert(responseData.Value);
                            }
                        }
                    } else {
                        alert(responseData.Value);
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="fileUpload">Select File to Upload:</label>
            <input type="file" id="fileUpload" />
            <br />
            <input type="button" value="Upload File" id="btnUploadFile" />
        </div>
    </form>
</body>
</html>
