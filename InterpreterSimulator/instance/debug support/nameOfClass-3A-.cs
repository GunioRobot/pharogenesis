nameOfClass: classOop
	(self sizeBitsOf: classOop) = 16r20 ifTrue:
		[^ (self nameOfClass:
				(self fetchPointer: 6 "thisClass" ofObject: classOop)) , ' class'].
	^ self stringOf: (self fetchPointer: 6 "name" ofObject: classOop)