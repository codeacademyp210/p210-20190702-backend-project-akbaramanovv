$(document).ready(function () {

    $("#fitness-table").on("click", ".myDeleteButton", function () {

        let btn = $(this);
        if (confirm("Are you Sure Delete ?")) {

            let id = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Packages/RoomDelete/" + id,
                success: function () {
                    btn.parent().parent().remove();
                }
            })
        }
    })
})