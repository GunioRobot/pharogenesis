ffiCall: address WithFlags: callType Args: argArray AndTypes: argTypeArray OfSize: nArgs
	"Generic callout. Does the actual work."
	| argType argTypes oop argSpec argClass |
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
	1 to: nArgs do:[:i|
		argType _ interpreterProxy fetchPointer: i ofObject: argTypes.
		argSpec _ interpreterProxy fetchPointer: 0 ofObject: argType.
		argClass _ interpreterProxy fetchPointer: 1 ofObject: argType.
		oop _ interpreterProxy fetchPointer: i-1 ofObject: argArray.
		self ffiArgument: oop Spec: argSpec Class: argClass.
		interpreterProxy failed ifTrue:[^0]. "coercion failed"
	].
	"Go out and call this guy"
	^self ffiCalloutTo: address WithFlags: callType