addSelector: selector withMethod: compiledMethod 
	"Add the message selector with the corresponding compiled method to the 
	receiver's method dictionary."

	| oldMethod |
	oldMethod _ self lookupSelector: selector.
	self methodDict at: selector put: compiledMethod.

	"Now flush Squeak's method cache, either by selector or by method"
	oldMethod == nil ifFalse: [oldMethod flushCache].
	selector flushCache