buttonExtent
	| size |
	size := Preferences scrollBarsNarrow
				ifTrue: [11]
				ifFalse: [15].
	^ bounds isWide
		ifTrue: [size @ self innerBounds height]
		ifFalse: [self innerBounds width @ size]