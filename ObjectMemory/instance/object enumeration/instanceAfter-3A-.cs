instanceAfter: objectPointer 
	"Support for instance enumeration. Return the next instance 
	of the class of the given object, or nilObj if the enumeration 
	is complete."
	| classPointer thisObj thisClass |
	classPointer _ self fetchClassOf: objectPointer.
	thisObj _ self accessibleObjectAfter: objectPointer.
	[thisObj = nil]
		whileFalse: [thisClass _ self fetchClassOf: thisObj.
			thisClass = classPointer ifTrue: [^ thisObj].
			thisObj _ self accessibleObjectAfter: thisObj].
	^ nilObj