toggleBackFillsOf: edge at: yValue validate: aBool
	"Toggle the faces of the (back) edge"
	| face |
	face _ edge leftFace.
	(face flags anyMask: FlagFaceActive)
		ifTrue:[	(aBool and:[face == fillList first]) ifTrue:[self error:'Not a back face'].
				fillList remove: face]
		ifFalse:[	fillList addBack: face.
				"Check for possible intersections of back and front face"
				self checkIntersectionOf: fillList first
					with: face at: yValue edge: edge].
	face flags: (face flags bitXor: FlagFaceActive).
	face _ edge rightFace.
	face == nil ifTrue:[^self].
	(face flags anyMask: FlagFaceActive)
		ifTrue:[	(aBool and:[face == fillList first]) ifTrue:[self error:'Not a back face'].
				fillList remove: face]
		ifFalse:[	fillList addBack: face.
				"Check for possible intersections of back and front face"
				self checkIntersectionOf: fillList first
					with: face at: yValue edge: edge].
	face flags: (face flags bitXor: FlagFaceActive).
