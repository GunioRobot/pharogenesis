keyframeData: aSymbol
	| data |
	data _ self valueOfProperty: aSymbol.
	data isNil ifFalse:[^data].
	data _ FlashKeyframes new.
	self setProperty: aSymbol toValue: data.
	^data