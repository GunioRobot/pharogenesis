validateSortOrder
	| backFace |
	firstFace == lastFace ifTrue:[^self]. "0 or 1 element"
	backFace _ firstFace nextFace.
	[backFace nextFace == nil] whileFalse:[
		backFace minZ <= backFace nextFace minZ ifFalse:[^self error:'Sorting error'].
		backFace _ backFace nextFace.
	].