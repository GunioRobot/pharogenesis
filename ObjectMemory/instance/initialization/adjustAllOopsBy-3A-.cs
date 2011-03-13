adjustAllOopsBy: bytesToShift
	"Adjust all oop references by the given number of bytes. This is done just after reading in an image when the new base address of the object heap is different from the base address in the image."
	"ar 10/7/1998 - Clear the RootBit of all objects"
	"di 11/18/2000 - return number of objects found"

	| oop header totalObjects |
	"Note: Don't bypass this method even if bytesToShift is zero 
		until the RootBit problem has been fixed in the appropriate places."
	"bytesToShift = 0 ifTrue: [ ^ nil ]."

	totalObjects _ 0.
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue: [
		(self isFreeObject: oop) ifFalse: [
			totalObjects _ totalObjects + 1.
			header _ self longAt: oop.
			self longAt: oop put: (header bitAnd: AllButRootBit).
			self adjustFieldsAndClassOf: oop by: bytesToShift.
 		].
		oop _ self objectAfter: oop.
	].
	^totalObjects
