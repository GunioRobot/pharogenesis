at: index put: aCharacter 
	"Store the Character in the field of the receiver indicated by the index."
	aCharacter isCharacter ifFalse:[self errorImproperStore].
	self wordAt: index put: aCharacter asInteger.
	^aCharacter