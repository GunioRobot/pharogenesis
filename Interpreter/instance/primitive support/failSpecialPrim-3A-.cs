failSpecialPrim: primIndex
	"Used only for failing from a primitive that was entered as a special
	bytecode.  This routine will look up the real method and, only if its
	primitiveIndex is different, then it will run that primitive, otherwise
	it will simply activate to run the fail code"
	| bytecode selectorIndex newReceiver rcvrClass |
	bytecode _ self getCurrentBytecode.
	(bytecode < 176 or: [bytecode > 207])
		ifTrue: ["Primitive was not running as a special bytecode"
				^ self primitiveFail].
	selectorIndex _ (bytecode - 176) * 2.
	messageSelector _ self fetchPointer: selectorIndex
				ofObject: (self splObj: SpecialSelectors).
	argumentCount _ self quickFetchInteger: selectorIndex + 1
				ofObject: (self splObj: SpecialSelectors).
"
	self sendSelector: messageSelector argumentCount: count
"
	"The above line of code must be expanded and altered, because we only
	want to run the ST code, not re-run the primitive and get into a loop"
	newReceiver _ self stackValue: argumentCount.
	rcvrClass _ self fetchClassOf: newReceiver.
	self findNewMethodInClass: rcvrClass.
	(primitiveIndex > 37 and: [primitiveIndex ~= primIndex])
		ifTrue: [self executeNewMethod]
		ifFalse: [self activateNewMethod]