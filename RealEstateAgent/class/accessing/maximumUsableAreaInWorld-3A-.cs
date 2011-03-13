maximumUsableAreaInWorld: aWorldOrNil

	| allowedArea |
	allowedArea _ Display usableArea.
	aWorldOrNil ifNotNil: [
		allowedArea := allowedArea intersect: aWorldOrNil visibleClearArea.
	].
	^allowedArea