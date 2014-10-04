//Function To Display Popup
function showPopUp() {
    document.getElementById('popupContainer').style.display = "block";
}
//Function To Check Target Element
function check(e) {
    var target = (e && e.target) || (event && event.srcElement);
    var obj = document.getElementById('popupContainer');
    checkParent(target) ? obj.style.display = 'none' : null;
}

function checkParent(t) {
    while (t.parentNode) {
        if (t == document.getElementById('popupContainer')) {
            return false;
        } else if (t == document.getElementById('close')) {
            return true;
        }
        t = t.parentNode;
    }
    return true;
}