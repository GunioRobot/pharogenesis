accessibleObjectAfter: oop 
	"Return the accessible object following the given object or 
	free chunk in the heap. Return nil when heap is exhausted."
	| obj |
	self inline: false.
	obj _ self objectAfter: oop.
	[obj < endOfMemory]
		whileTrue: [(self isFreeObject: obj) ifFalse: [^ obj].
			obj _ self objectAfter: obj].
	^ nil