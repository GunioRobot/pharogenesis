proceed
	"Proceed execution of the receiver's model, starting after the expression at 
	which an interruption occurred."

	self controlTerminate.
	model proceed: view topView controller.
	self controlInitialize