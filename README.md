Release Notes 1.1:

1. How to run instructions:
	
		To Run application: 
	
		A) Make sure TaxPlaySlip is set as startup app. To do so: 
		
		1.1 Right click on TaxPlaySlip Project and Set up as Startup project.
    1.2 Build solution and run.
			
2. Test Inputs and outputs are as is stated in Unit Test Project

3. use route to test api : "http://localhost:56492/api/payslip/GeneratePaySlip"
	Sample input : 
  {	
      "firstName" : "David",
      "lastName" : "Miller",
      "annualSalary" : 38000,
      "superRate" : 9,
      "startDate" : "01 March – 31 March"
  }
	
	
