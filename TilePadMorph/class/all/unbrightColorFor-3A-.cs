unbrightColorFor: aColor

	ColorsForType do: [:pair |
		(pair at: 2) = aColor ifTrue: [^ (pair at: 1)]].
	^ aColor
