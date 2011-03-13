send
	"Evaluate the next expression in the receiver's model's currently selected 
	method, after the point at which interruption occurred."

	self controlTerminate.
	model send.
	self controlInitialize