$.ajax({
    type: "Get",
    url: "/Controller/UserApi/GetUsers",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (data) {
        {
            var img = '@Url.Action("Image", new {id = "imgid"})'.replace("imgid", encodeURIComponent(item.Id));
            $.each(data, function (i, item) {
                var userdiv =
                    "<div id='usercontainer'>"
                    "<img width='150' height='auto' src=" + img + " />" +
                    "<p>" + item.NickName + "</p>" +
                    "</div>";
                $('#container').append(userdiv);
            });
        }
    }
});