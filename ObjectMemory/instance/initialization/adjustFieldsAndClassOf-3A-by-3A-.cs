adjustFieldsAndClassOf: oop by: offsetBytes
	"Adjust all pointers in this object by the given offset."

	| fieldAddr fieldOop classHeader newClassOop |
	fieldAddr _ oop + (self lastPointerOf: oop).
	[fieldAddr > oop] whileTrue: [
		fieldOop _ self longAt: fieldAddr.
		(self isIntegerObject: fieldOop) ifFalse: [
			self longAt: fieldAddr put: (fieldOop + offsetBytes).
		].
		fieldAddr _ fieldAddr - 4.
	].

	(self headerType: oop) ~= HeaderTypeShort ifTrue: [
		"adjust class header if not a compact class"

		classHeader _ self longAt: (oop - 4).
		newClassOop _
			(classHeader bitAnd: AllButTypeMask) + offsetBytes.
		self longAt: (oop - 4) put: (newClassOop bitOr: (classHeader bitAnd: TypeMask)).
	].
