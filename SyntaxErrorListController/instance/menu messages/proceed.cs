proceed
	"The user has completed editing the model of the receiver and evaluating 
	in the context in which the syntax error interrupt should now continue."

	self controlTerminate.
	model proceed: view topView controller.
	self controlInitialize