ffiPushPointerContentsOf: oop
	"Push the contents of the given external structure"
	| ptrValue ptrClass ptrAddress |
	self inline: false.
	ptrValue _ oop.
	ptrClass _ interpreterProxy fetchClassOf: ptrValue.
	ptrClass == interpreterProxy classExternalAddress ifTrue:[
		ptrAddress _ interpreterProxy fetchWord: 0 ofObject: ptrValue.
		"Don't you dare to pass pointers into object memory"
		(interpreterProxy isInMemory: ptrAddress)
			ifTrue:[^self ffiFail: FFIErrorInvalidPointer].
		^self ffiPushPointer: ptrAddress].
	ptrClass == interpreterProxy classByteArray ifTrue:[
		ptrAddress _ self cCoerce: (interpreterProxy firstIndexableField: ptrValue) to: 'int'.
		^self ffiPushPointer: ptrAddress].
	^self ffiFail: FFIErrorBadArg