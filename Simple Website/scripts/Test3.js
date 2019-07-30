/*
  Name: Zachary Moore
  Due Date: 08/18/2018
  Abstract: JavaScript for Test 3: 
              * Performs user-selected mathematical operation
                on input values and displays result
*/
function CalculateTotal(){
  // Declare variables
  var intValue1 = 0;
  var intValue2 = 0;
  var strOperation = "";
  var intTotal = 0;
  
  // Get inputs
  intValue1 = document.getElementById("txtValue1").value;
  intValue2 = document.getElementById("txtValue2").value;
  strOperation = document.getElementById("selOperation").value;
  
  // Convert text to number
  intValue1 = Number(intValue1);
  intValue2 = Number(intValue2);
  
  // Are both inputs numbers?
  if(!isNaN(intValue1) && !isNaN(intValue2)){
    // Yes! Perform calculation
    switch(strOperation){
      case "add":
        intTotal = intValue1 + intValue2;
        console.log(intTotal);
        break;
      case "subtract":
        intTotal = intValue1 - intValue2;
        console.log(intTotal);
        break;
      case "multiply":
        intTotal = intValue1 * intValue2;
        console.log(intTotal);
        break;
      case "divide":
        intTotal = intValue1 / intValue2;
        console.log(intTotal);
        break;
    }
    
    // Display result
    document.getElementById("txtTotal").value = intTotal;
  }
  else{
    // No, display error message
    alert("Please input only numbers for Value 1 and Value 2.");
  }
}

// Click event handler
document.getElementById("btnCalculateTotal").onclick = CalculateTotal;