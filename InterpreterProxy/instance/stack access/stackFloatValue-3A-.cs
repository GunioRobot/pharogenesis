stackFloatValue: offset
	| oop |
	self returnTypeC: 'double'.
	oop _ self stackValue: offset.
	(self isFloatObject: oop) ifFalse: [self primitiveFail. ^0.0].
	^oop