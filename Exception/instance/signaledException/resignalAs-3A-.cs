resignalAs: replacementException
	"Signal an alternative exception in place of the receiver."

	thisContext unwindTo: initialContext.
	replacementException initialContext: initialContext.
	resignalException := replacementException