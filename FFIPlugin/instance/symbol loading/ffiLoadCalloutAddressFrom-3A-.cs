ffiLoadCalloutAddressFrom: oop
	"Load the function address for a call out to an external function"
	| module moduleHandle functionName functionLength address |
	self inline: false.
	"First find and load the module"
	module _ interpreterProxy fetchPointer: 4 ofObject: oop.
	moduleHandle _ self ffiLoadCalloutModule: module.
	interpreterProxy failed ifTrue:[^0]. "failed"
	"fetch the function name"
	functionName _ interpreterProxy fetchPointer: 3 ofObject: oop.
	(interpreterProxy isBytes: functionName) ifFalse:[^self ffiFail: FFIErrorBadExternalFunction].
	functionLength _ interpreterProxy byteSizeOf: functionName.
	address _ interpreterProxy ioLoadSymbol: 
					(self cCoerce: (interpreterProxy firstIndexableField: functionName) to:'int')
					OfLength: functionLength 
					FromModule: moduleHandle.
	(interpreterProxy failed or:[address = 0])
		ifTrue:[^self ffiFail: FFIErrorAddressNotFound].
	^address