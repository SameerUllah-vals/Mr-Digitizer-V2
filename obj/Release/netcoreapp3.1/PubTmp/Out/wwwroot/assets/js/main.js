var weekday = new Array(7);
weekday[0] = "Sunday";
weekday[1] = "Monday";
weekday[2] = "Tuesday";
weekday[3] = "Wednesday";
weekday[4] = "Thursday";
weekday[5] = "Friday";
weekday[6] = "Saturday";
function isDoubleClicked(element) {
    //if already clicked return TRUE to indicate this click is not allowed
    if (element.data("isclicked")) return true;

    //mark as clicked for 1 second
    element.data("isclicked", true);
    setTimeout(function () {
        element.removeData("isclicked");
    }, 2000);

    //return FALSE to indicate this click was allowed
    return false;
}

var ConvertDateTimeToDate = function (n) {
    var fullDate = new Date(n); console.log(fullDate);
    var twoDigitMonth = fullDate.getMonth() + "";
    if (twoDigitMonth.length == 1)
        twoDigitMonth = "0" + twoDigitMonth;
    var twoDigitDate = fullDate.getDate() + "";
    if (twoDigitDate.length == 1)
        twoDigitDate = "0" + twoDigitDate;
    var currentDate = twoDigitDate + "/" + twoDigitMonth + "/" + fullDate.getFullYear(); console.log(currentDate);
    return currentDate;
};

function formatDate(date) {
    date = new Date(date);
    var year = date.getFullYear(),
        month = date.getMonth() + 1, // months are zero indexed
        day = date.getDate(),
        hour = date.getHours(),
        minute = date.getMinutes(),
        second = date.getSeconds(),
        hourFormatted = hour % 12 || 12, // hour returned in 24 hour format
        minuteFormatted = minute < 10 ? "0" + minute : minute,
        morning = hour < 12 ? "am" : "pm";

    return month + "/" + day + "/" + year + " " + hourFormatted + ":" +
        minuteFormatted + morning;
}

function formatmonthYear(date) {
    var d = new Date(date);
    var month = new Array();
    month[0] = "January";
    month[1] = "February";
    month[2] = "March";
    month[3] = "April";
    month[4] = "May";
    month[5] = "June";
    month[6] = "July";
    month[7] = "August";
    month[8] = "September";
    month[9] = "October";
    month[10] = "November";
    month[11] = "December";
    var n = month[d.getMonth()];
    return n + ', ' + d.getFullYear();
}

function getMaxOfArray(numArray) {
    return Math.max.apply(null, numArray);
}
var AjaxGenericCalls = {
    ajaxRequest: function (paramObj) {
        return new Promise(function (resolve, reject) {
            $.ajax(paramObj).done(function (response) {
                resolve(response);
            }).fail(function (response) {
                reject(response);
            })
        });
    }
}
var minTwoDigits = function (n) {
    return (n < 10 ? '0' : '') + n;
}
var CreateDateFromPicker = function (dt) {
    var match = /(\d+)\/(\d+)\/(\d+)/.exec(dt);
    if (match != null) {
        var newDate = new Date(match[3], match[2], match[1]);
        return newDate;
    } else {
        return dt;
    }
}
$(document).on("click", "a", function () {
    if ($(this).hasClass("disabled")) {
        return false;
    }
});
var formLoader = ".preloader-wrapper";
var contentArea = ".content-area";
var responseArea = "#response_area";
var DisableView = function () {
    $('form').find("input[type='text'],input[type='password'],textarea,input[type='checkbox'],input[type='radio'],select").each(function () {
        $(this).attr("disabled", "disabled");
    });
    $('.AddMoreRowClass').hide();
    $('form').removeAttr("action");
}
var EnableDisableArea = function (area, object_type) {
    var main_context = $('form');
    if (area != "") {
        main_context = $(area);
    }
    if (object_type == "Disable") {
        main_context.find("submit,button,input[type='checkbox'],input[type='radio'],select").each(function () {
            $(this).attr("disabled", "disabled");
        });
        main_context.find("input[type='text'],input[type='password'],textarea").each(function () {
            $(this).attr("readonly", "readonly");
        });
        main_context.find("a").each(function () {
            $(this).addClass("disabled");
        });
    } else {
        main_context.find("input[type='text'],input[type='password'],textarea").each(function () {
            $(this).removeAttr("readonly");
        });
        main_context.find("a").each(function () {
            $(this).removeClass("disabled");
        });
        main_context.find("submit,button,input[type='checkbox'],input[type='radio'],select").each(function () {
            $(this).removeAttr("disabled");
        });
    }
}
onFormSubmitBegin = function () {
    var isValid = true;
    if (isValid) {
        EnableDisableArea("", "Disable");
        $(contentArea).css('display', 'none');
        if ($(formLoader).length > 0) {
            $(formLoader).css('display', 'block');
        }
    } else {
        return false;
    }
}
onFormSubmitComplete = function () {

}
onFormFailure = function (response) {
    EnableDisableArea("", "Enable");
    if ($(formLoader).length > 0) {
        var response_area_context = $(responseArea);
        response_area_context.html(response);
        response_area_context.toggleClass('text-danger');
        $(formLoader).css('display', 'none');
        $(contentArea).css('display', 'block');
    }
}
onFormSuccess = function (response) {
    console.log(response);
    var className = "";
    var response_area_context = $(responseArea);
    if ($(formLoader).length > 0) {
        response_area_context.html("");
        response_area_context.removeClass();
    }
    var responseTypeArray = response.Type.split('-');
    if (response.Success == true) {
        className = "text-success";
    } else {
        className = "text-danger";
    }
    $.each(responseTypeArray, function (key, value) {
        if (value == "M") {
            if ($(formLoader).length > 0) {
                response_area_context.html(response.Message);
                response_area_context.addClass(className);
                M.toast({ html: response.Message, classes: 'rounded' });
            }
        } else if (value == "R") {
            $('form')[0].reset();
            $(".hidea-area").hide();
            if ($(".select2-zero").length > 0) {
                $(".select2-zero").select2("val", "0");
                $(".select2-zero").trigger('change.select2');
            } else if ($(".select2-hidden-accessible").length > 0) {
                $(".select2-hidden-accessible").select2("val", "");
                $(".select2-hidden-accessible").trigger('change.select2');
            }
        } else if (value == "T") {
            window.location = response.TargetURL;
        } else if (value == "TD") {
            setTimeout(function () {
                window.location = response.TargetURL;
            }, 2000);
        }
        else if (value == "D") {
            $('#data').html(response.Data);
        }
        else if (value == "RL") {
            window.location.reload();
        } else if (value == "RLD") {
            setTimeout(function () {
                window.location.reload();
            }, 2000);
        }
    });
    EnableDisableArea("", "Enable");
    $(contentArea).css('display', 'block');
    if ($(formLoader).length > 0) {
        $(formLoader).css('display', 'none');
    }
}