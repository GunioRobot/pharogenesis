primitiveNextObject
	"Return the object following the receiver in the heap. Return the SmallInteger zero when there are no more objects."

	| object instance |
	object _ self stackTop.
	instance _ self accessibleObjectAfter: object.
	instance = nil
		ifTrue: [ self pop: argumentCount+1.
			self pushInteger: 0 ]
		ifFalse: [ self pop: argumentCount+1 thenPush: instance ].