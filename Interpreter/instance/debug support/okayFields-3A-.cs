okayFields: oop
	"If this is a pointers object, check that its fields are all okay oops."

	| i fieldOop |
	(oop = nil or: [oop = 0]) ifTrue: [ ^true ].
	(self isIntegerObject: oop) ifTrue: [ ^true ].
	self okayOop: oop.
	self oopHasOkayClass: oop.
	(self isPointers: oop) ifFalse: [ ^true ].
	i _ (self lengthOf: oop) - 1.
	[i >= 0] whileTrue: [
		fieldOop _ self fetchPointer: i ofObject: oop.
		(self isIntegerObject: fieldOop) ifFalse: [
			self okayOop: fieldOop.
			self oopHasOkayClass: fieldOop.
		].
		i _ i - 1.
	].