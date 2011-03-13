addDependent: anObject 
	"Add anObject as one of the receiver's dependents."

	self dependents isEmpty ifTrue: [self setDependents].
	self dependents add: anObject.
	^anObject