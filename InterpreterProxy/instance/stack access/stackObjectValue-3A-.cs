stackObjectValue: offset
	| oop |
	oop _ self stackValue: offset.
	(self isIntegerObject: oop) ifTrue: [self primitiveFail. ^ nil].
	^oop