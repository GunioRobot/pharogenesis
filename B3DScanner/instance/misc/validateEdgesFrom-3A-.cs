validateEdgesFrom: aCollection
	"aCollection must contain two entries for each face."
	| faceNum face faces |
	faceNum _ 0.
	aCollection do:[:edge|
		edge leftFace ifNil:[self error:'Bad edge'] ifNotNil:[faceNum _ faceNum + 1].
		edge rightFace ifNotNil:[faceNum _ faceNum + 1].
	].
	faceNum \\ 2 = 0 ifTrue:[^self].
	faces _ Bag new.
	aCollection do:[:edge|
		face _ edge leftFace.
		faces add: face.
		(aet indexOf: face leftEdge) = 0 ifTrue:[self error:'Left edge not in AET'].
		(aet indexOf: face rightEdge) = 0 ifTrue:[self error:'Right edge not in AET'].
		face _ edge rightFace.
		face == nil ifFalse:[
			faces add: face.
			(aet indexOf: face leftEdge) = 0 ifTrue:[self error:'Left edge not in AET'].
			(aet indexOf: face rightEdge) = 0 ifTrue:[self error:'Right edge not in AET'].
		].
	].
	self error:'Something *IS* wrong here'.