removeSelector: selector
	"Remove all memory of changes associated with the argument, selector, in 
	this class."

	methodChanges removeKey: selector ifAbsent: []