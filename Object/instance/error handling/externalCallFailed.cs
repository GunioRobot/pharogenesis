externalCallFailed
	"A call to an external function has failed."
	^(Smalltalk at: #ExternalFunction ifAbsent:[^self error: 'FFI not installed'])
		externalCallFailed