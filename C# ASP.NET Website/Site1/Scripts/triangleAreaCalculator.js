function calculateArea() {
    var width = document.getElementById("txtWidth").value;
    var height = document.getElementById("txtHeight").value;
    var area = 0.5 * width * height;
    document.getElementById("txtArea").value = area;
}