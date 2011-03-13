keyframeData: aSymbol
	| data |
	data := self valueOfProperty: aSymbol.
	data isNil ifFalse:[^data].
	data := FlashKeyframes new.
	self setProperty: aSymbol toValue: data.
	^data