firstAccessibleObject
	"Return the first accessible object in the heap."

	| obj |
	obj _ self firstObject.
	[obj < endOfMemory] whileTrue: [
		(self isFreeObject: obj) ifFalse: [ ^obj ].
		obj _ self objectAfter: obj.
	].
	self error: 'heap is empty'