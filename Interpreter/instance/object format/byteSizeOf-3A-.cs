byteSizeOf: oop
	| slots |
	(self isIntegerObject: oop) ifTrue:[^0].
	slots _ self slotSizeOf: oop.
	(self isBytesNonInt: oop)
		ifTrue:[^slots]
		ifFalse:[^slots * 4]