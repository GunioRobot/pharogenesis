primitiveNextObject
	"Return the object following the receiver in the heap. Return the SmallInteger zero when there are no more objects."

	| object instance |
	object _ self popStack.
	instance _ self accessibleObjectAfter: object.
	instance = nil
		ifTrue: [ self pushInteger: 0 ]
		ifFalse: [ self push: instance ].