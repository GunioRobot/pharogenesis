step
	"Evaluate the next message of the sequence that is initiated by evaluating 
	the next expression in the receiver's model's currently selected method, 
	after the point at which interruption occurred."

	self controlTerminate.
	model step.
	self controlInitialize