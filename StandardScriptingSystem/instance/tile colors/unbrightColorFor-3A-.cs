unbrightColorFor: aColor
	TypeColorDictionary do: [:pair |
		(pair at: 2) = aColor ifTrue: [^ (pair at: 1)]].
	^ aColor
