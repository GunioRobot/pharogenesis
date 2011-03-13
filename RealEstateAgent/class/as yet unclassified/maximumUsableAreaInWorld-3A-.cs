maximumUsableAreaInWorld: aWorldOrNil

	| allowedArea |
	allowedArea _ Display usableArea.
	aWorldOrNil ifNotNil: [allowedArea _ allowedArea intersect: aWorldOrNil viewBox].
	^allowedArea
