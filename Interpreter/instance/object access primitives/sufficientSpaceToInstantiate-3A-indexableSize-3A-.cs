sufficientSpaceToInstantiate: classOop indexableSize: size
	"Return the number of bytes required to allocate an instance of the given class with the given number of indexable fields."
	"Details: For speed, over-estimate space needed for fixed fields or literals; the low space threshold is a blurry line."

	| format okay |
	self inline: true.
	format _ ((self formatOfClass: classOop) >> 8) bitAnd: 16rF.

	"fail if attempting to call new: on non-indexable class"
	(size > 0 and: [format < 2]) ifTrue: [ ^ false ].

	format < 8 ifTrue: [
		"indexable fields are words or pointers"
		okay _ self sufficientSpaceToAllocate: (2500 + (size * 4)).
	] ifFalse: [
		"indexable fields are bytes"
		okay _ self sufficientSpaceToAllocate: (2500 + size).
	].

	^ okay