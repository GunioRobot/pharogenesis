brightColorFor: aColor

	ColorsForType do: [:pair |
		(pair at: 1) = aColor ifTrue: [^ (pair at: 2)]].
	^ aColor
