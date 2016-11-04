$(document).ready(function() {
  
    $("#sumbit").click(function() {
        var formData = new FormData();
        var file = document.getElementById("fileInput").files[0];
        formData.append("fileInput", file);

        $.ajax({
            url : "Home/UploadImageAjax",
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function() {
                alert("URA");
            }
        });
   
    });
})