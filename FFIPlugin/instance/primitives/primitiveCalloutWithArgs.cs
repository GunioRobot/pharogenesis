primitiveCalloutWithArgs
	"Perform a function call to a foreign function.
	Only invoked from ExternalFunction>>invokeWithArguments:"
	| lit address flags argTypes litClass nArgs argArray |
	self export: true.
	self inline: false.
	self ffiSetLastError: FFIErrorGenericError. "educated guess if we fail silently"
	lit _ nil.
	"Look if the method is itself a callout function"
	lit _ interpreterProxy stackValue: interpreterProxy methodArgumentCount.
	litClass _ interpreterProxy fetchClassOf: lit.
	(interpreterProxy includesBehavior: litClass 
						ThatOf: interpreterProxy classExternalFunction) 
		ifFalse:[^self ffiFail: FFIErrorNotFunction].
	address _ self ffiLoadCalloutAddress: lit.
	interpreterProxy failed ifTrue:[^nil].
	"Load and check the other values before we call out"
	flags _ interpreterProxy fetchInteger: 1 ofObject: lit.
	interpreterProxy failed ifTrue:[^self ffiFail: FFIErrorBadArgs].
	argTypes _ interpreterProxy fetchPointer: 2 ofObject: lit.
	"must be array of arg types"
	(interpreterProxy isArray: argTypes) 
		ifFalse:[^self ffiFail: FFIErrorBadArgs].
	nArgs _ interpreterProxy slotSizeOf: argTypes.
	(interpreterProxy methodArgumentCount = 1) 
		ifFalse:[^self ffiFail: FFIErrorBadArgs].
	argArray _ interpreterProxy stackValue: 0.
	(interpreterProxy isArray: argArray)
		ifFalse:[^self ffiFail: FFIErrorBadArgs].
	nArgs = ((interpreterProxy slotSizeOf: argArray) + 1)
		ifFalse:[^self ffiFail: FFIErrorBadArgs].
	self ffiInitialize. "announce the execution of an external call"
	self ffiCall: address 
		WithFlags: flags 
		Args: argArray
		AndTypes: argTypes
		OfSize: nArgs-1.
	self ffiCleanup. "cleanup temp allocations"
	^0