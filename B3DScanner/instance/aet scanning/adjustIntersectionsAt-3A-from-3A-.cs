adjustIntersectionsAt: yValue from: topEdge
	"The top face has changed. Adjust for possible intersections in the same scan line."
	| frontFace backFace |
	frontFace _ fillList first.

	"If frontFace is nil then the fillList is empty.
	If frontFace nextFace is nil then there is only one face in the list."
	(frontFace == nil or:[frontFace nextFace == nil]) ifTrue:[^self].

	"Now, search the fill list until we reach the first face with minZ > face maxZ.
	Note that we have a linked list and can thus start from frontFace nextFace 
	until we reach the end of the face list (nil)."
	backFace _ frontFace nextFace.
	[backFace == nil] whileFalse:[
		(self checkIntersectionOf: frontFace with: backFace at: yValue edge: topEdge)
			ifFalse:[^self]. "Aborted."
		backFace _ backFace nextFace.
	].