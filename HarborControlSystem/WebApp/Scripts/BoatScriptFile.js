function BoatProgress() {
    var y = 1;
    RecursiveCall(y);
}

//Boats Progress
function RecursiveCall(y) {    
    var id = 0;
    var loop = y;
    var countBoat = $(".myProgress").length;
        var i = 0;       
        if (i === 0) {
            i = 1;
            var elem = document.getElementById(y);            
            var time = elem.getAttribute('data-time');
            var width = 1;
            id = setInterval( function () {
                if (width >= 100) {

                        clearInterval(id);
                        i = 0;
                        loop++;                      
                    $('#' + y + 'Reach').show();
                    $('#' + y + 'Load').hide(); 
                        if (loop <= countBoat)
                            RecursiveCall(loop);
                        else
                            $('#ReloadBoatHarbor').show();
                    } else {
                        width++;
                        elem.style.width = width + "%";
                    }
                }, time);
        }
}




//#region Validations

//Numeric value validation
function validatenumerics(key) {
    //getting key code of pressed key
    var keycode = (key.which) ? key.which : key.keyCode;

    //comparing pressed keycodes
    if (keycode !== 46 && keycode > 31 && (keycode < 48 || keycode > 57)) {
        toastr.error('Only numbers allowed !');
        return false;
    }
    else return true;
}

//#endregion Validations


//#region Events

function AddBoatToHarbor() {

    var boatCount = $("#BoatsCount").val();
    if (boatCount > 0) {
        $('#ReloadBoatHarbor').hide();
        var boatsCount = $("#BoatsCount").val();
        $("#BoatsCountDiv").hide();
        $.ajax({
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            url: '/Home/Boats',
            dataType: 'html',
            data: { count: boatsCount },
            success: function (result) {
                $('#BoatHarbor').html(result);
                $('#BoatHarbor').show();
                BoatProgress();

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });  
    }
}


function RealodBoatToHarbor() {
  
    $("#BoatsCount").val("0");   
    $('#BoatHarbor').hide();
    $("#BoatsCountDiv").show();
    $('#ReloadBoatHarbor').hide(); 
}
//#endregion

$(document).on('keypress', function (e) {
    var boatCount = $("#BoatsCount").val();
    if (e.which === 13 && boatCount > 0) {
        AddBoatToHarbor();
    }
});