ffiCall: address WithFlags: callType AndTypes: argTypeArray
	"Generic callout. Does the actual work."
	| stackIndex argType argTypes oop nArgs argClass argSpec |
	self inline: true.
	"check if the calling convention is supported"
	(self ffiSupportsCallingConvention: callType)
		ifFalse:[^self ffiFail: FFIErrorCallType].
	argTypes _ argTypeArray.
	"Fetch return type and args"
	argType _ interpreterProxy fetchPointer: 0 ofObject: argTypes.
	argSpec _ interpreterProxy fetchPointer: 0 ofObject: argType.
	argClass _ interpreterProxy fetchPointer: 1 ofObject: argType.
	self ffiCheckReturn: argSpec With: argClass.
	interpreterProxy failed ifTrue:[^0]. "cannot return"
	ffiRetOop _ argType.
	nArgs _ interpreterProxy methodArgumentCount.
	stackIndex _ nArgs - 1. "stack index goes downwards"
	1 to: nArgs do:[:i|
		argType _ interpreterProxy fetchPointer: i ofObject: argTypes.
		argSpec _ interpreterProxy fetchPointer: 0 ofObject: argType.
		argClass _ interpreterProxy fetchPointer: 1 ofObject: argType.
		oop _ interpreterProxy stackValue: stackIndex.
		self ffiArgument: oop Spec: argSpec Class: argClass.
		interpreterProxy failed ifTrue:[^0]. "coercion failed"
		stackIndex _ stackIndex - 1.
	].
	"Go out and call this guy"
	^self ffiCalloutTo: address WithFlags: callType