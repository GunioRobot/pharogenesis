stackObjectValue: offset
	"Ensures that the given object is a real object, not a SmallInteger."

	| oop |
	oop _ self longAt: stackPointer - (offset * 4).
	(self isIntegerObject: oop) ifTrue: [self primitiveFail. ^ nil].
	^ oop
