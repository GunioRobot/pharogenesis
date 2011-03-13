removeSelector: selector 
	"Assuming that the argument, selector (a Symbol), is a message selector 
	in my method dictionary, remove it and its method."

	^ self basicRemoveSelector: selector
