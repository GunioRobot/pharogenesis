restart
	"Proceed execution of the receiver's model, starting at the beginning of 
	the currently selected method."

	self controlTerminate.
	model restart: view topView controller.
	self controlInitialize