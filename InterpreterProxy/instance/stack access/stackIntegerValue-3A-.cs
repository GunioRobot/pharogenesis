stackIntegerValue: offset
	| oop |
	oop _ self stackValue: offset.
	(self isIntegerObject: oop) ifFalse: [self primitiveFail. ^0].
	^oop