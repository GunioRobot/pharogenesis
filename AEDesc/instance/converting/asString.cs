asString

	| theSize |
	((self at: 1) ~= 16r54455854) ifTrue:
		[^self error: 'AEDesc is not of type ''TEXT'''].
	(theSize _ self dataSize) < 0 ifTrue: [^self error: 'Invalid size for data'].
	^self primAEDescToString: (String new: theSize).
