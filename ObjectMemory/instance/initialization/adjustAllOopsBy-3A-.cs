adjustAllOopsBy: bytesToShift
	"Adjust all oop references by the given number of bytes. This is done just after reading in an image when the new base address of the object heap is different from the base address in the image."

	| oop last |
	bytesToShift = 0 ifTrue: [ ^ nil ].

	oop _ self firstObject.
	[oop < endOfMemory] whileTrue: [
		(self isFreeObject: oop) ifFalse: [
			self adjustFieldsAndClassOf: oop by: bytesToShift.
 		].
		last _ oop.
		oop _ self objectAfter: oop.
	].
