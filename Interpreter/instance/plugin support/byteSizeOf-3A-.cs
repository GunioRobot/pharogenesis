byteSizeOf: oop
	| slots |
	(self isIntegerObject: oop) ifTrue:[^0].
	slots _ self slotSizeOf: oop.
	(self isBytes: oop)
		ifTrue:[^slots]
		ifFalse:[^slots * 4]