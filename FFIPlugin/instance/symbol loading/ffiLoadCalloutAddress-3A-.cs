ffiLoadCalloutAddress: lit
	"Load the address of the foreign function from the given object"
	| addressPtr address ptr |
	self var: #ptr declareC:'int *ptr'.
	"Lookup the address"
	addressPtr _ interpreterProxy fetchPointer: 0 ofObject: lit.
	"Make sure it's an external handle"
	address _ self ffiContentsOfHandle: addressPtr errCode: FFIErrorBadAddress.
	interpreterProxy failed ifTrue:[^0].
	address = 0 ifTrue:["Go look it up in the module"
		(interpreterProxy slotSizeOf: lit) < 5 ifTrue:[^self ffiFail: FFIErrorNoModule].
		address _ self ffiLoadCalloutAddressFrom: lit.
		interpreterProxy failed ifTrue:[^0].
		"Store back the address"
		ptr _ interpreterProxy firstIndexableField: addressPtr.
		ptr at: 0 put: address].
	^address