/*
  Name: Zachary Moore
  Date: 8/4/2018
  Abstract: Script for Homework 18
*/
function ProcessInfo(){
  var strColor = prompt("Enter your favorite color", "blue");
  var strFirstName = document.getElementById("txtFirstName").value;
  var strAge = document.getElementById("txtAge").value;
  
  // Add default values for name and age if not given
  if (!strFirstName){
    strFirstName = "ANONYMOUS";
  }
  if (!strAge){
    strAge = "UNKNOWN";
  }
  
  // Change body color to favorite color
  document.body.style.backgroundColor = strColor;
  
  alert(strFirstName + ", your favorite color was applied to the background" +
        " of the page.\n\n Your age is " + strAge + ".");
}
document.getElementById("btnSubmit").onclick = ProcessInfo;