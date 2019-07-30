/*
  Name: Zachary Moore
  Assignment: Homework 19
  Due Date: 08/11/2018
*/
function calculateArea(){
  var intWidth = document.getElementById("txtWidth").value;
  var intHeight = document.getElementById("txtHeight").value;
  var intArea = 0;
  
  // Calculate area of the triangle
  intArea = (intWidth * intHeight) / 2;
  
  // Display area
  document.getElementById("txtArea").value = intArea;
}
document.getElementById("btnCalculate").onclick = calculateArea;