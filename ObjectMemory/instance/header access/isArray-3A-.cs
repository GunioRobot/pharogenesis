isArray: oop
	"Answer true if this is an indexable object with pointer elements, e.g., an array"
	^(self isNonIntegerObject: oop) and:[self isArrayNonInt: oop]