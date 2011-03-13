removeSelector: selector 
	"Assuming that the argument, selector (a Symbol), is a message selector 
	in the receiver's method dictionary, remove it. If the selector is not in 
	the method dictionary, create an error notification."

	methodDict removeKey: selector.
	self flushCache