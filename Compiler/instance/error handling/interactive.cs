interactive 
	"Answer whether there is a requestor of the compiler who should be 
	informed that an error occurred."

	^ (requestor == nil or: [requestor isKindOf: SyntaxError]) not