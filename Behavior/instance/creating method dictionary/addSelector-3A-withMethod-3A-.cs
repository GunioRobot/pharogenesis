addSelector: selector withMethod: compiledMethod 
	"Add the message selector with the corresponding compiled method to the 
	receiver's method dictionary."

	methodDict at: selector put: compiledMethod.
	self flushCache