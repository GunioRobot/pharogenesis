validate
	| face |
	(firstFace == nil and:[lastFace == nil]) ifTrue:[^self].
	firstFace prevFace == nil ifFalse:[^self error:'Bad list'].
	lastFace nextFace == nil ifFalse:[^self error:'Bad list'].
	face _ firstFace.
	[face == lastFace] whileFalse:[face _ face nextFace].
	self validateSortOrder.