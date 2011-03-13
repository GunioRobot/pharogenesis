removeDependent: anObject 
	"Remove the argument, anObject, as one of the receiver's dependents."

	self dependents remove: anObject ifAbsent: [].
	self dependents isEmpty ifTrue: [self breakDependents].
	^anObject