objectAfter: oop
	"Return the object or free chunk immediately following the given object or free chunk in memory. Return endOfMemory when enumeration is complete."

	| sz |
	self inline: true.
	DoAssertionChecks ifTrue: [
		oop >= endOfMemory ifTrue: [ self error: 'no objects after the end of memory' ].
	].

	(self isFreeObject: oop)
		ifTrue: [ sz _ self sizeOfFree: oop ]
		ifFalse: [ sz _ self sizeBitsOf: oop ].

	^ self oopFromChunk: (oop + sz)