initialInstanceOf: classPointer 
	"Support for instance enumeration. Return the first instance 
	of the given class, or nilObj if it has no instances."
	| thisObj thisClass |
	thisObj _ self firstAccessibleObject.
	[thisObj = nil]
		whileFalse: [thisClass _ self fetchClassOf: thisObj.
			thisClass = classPointer ifTrue: [^ thisObj].
			thisObj _ self accessibleObjectAfter: thisObj].
	^ nilObj