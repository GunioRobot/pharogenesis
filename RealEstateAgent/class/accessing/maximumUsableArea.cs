maximumUsableArea

	| allowedArea |
	allowedArea _ Display usableArea.
	Smalltalk isMorphic ifTrue: [
		allowedArea := allowedArea intersect: ActiveWorld visibleClearArea.
	].
	^allowedArea