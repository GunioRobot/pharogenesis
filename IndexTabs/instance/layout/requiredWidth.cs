requiredWidth
	submorphs size = 0
		ifTrue:
			[^ self basicWidth].
	^ (submorphs detectSum: [:m | m width]) + (submorphs size * padding)