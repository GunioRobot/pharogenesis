toggleTopFillsOf: edge at: yValue
	"Toggle the faces of the (new top) edge.
	We must carefully treat each of the following cases:
		1) rightFace notNil (e.g., two faces)
			a) rightFace active ~= leftFace active
				=> simply swap leftFace and rightFace in the face list
			b) rightFace active not & leftFace active not
				=> edge defines new boundary entry; check for minimal dxdz and insert in order
			c) rightFace active & leftFace active
				=> edge defines boundary exit; search all faces for minimal z value
		2) rightFace isNil (e.g., single face)
			a) leftFace active
				=> edge defines boundary exit; see 1c)
			b) leftFace active not
				=> edge defines boundary entry; simply put it on top.
	"
	| leftFace rightFace xorMask noTest |
	edge == lastIntersection 
		ifTrue:[^self toggleIntersectionEdge: edge].
	noTest _ true.
	leftFace _ edge leftFace.
	rightFace _ edge rightFace.
	rightFace == nil ifTrue:[
		(leftFace flags anyMask: FlagFaceActive)
			ifTrue:[	leftFace == fillList first | noTest ifFalse:[self error:'Oops'].
					fillList remove: leftFace.
					fillList searchForNewTopAtX: edge xValue y: yValue]
			ifFalse:[	fillList addFront: leftFace].
		leftFace flags: (leftFace flags bitXor: FlagFaceActive).
		^self].
	"rightFace notNil"
	xorMask _ leftFace flags bitXor: rightFace flags.
	(xorMask anyMask: FlagFaceActive) ifTrue:[
		"Simply swap"
		(leftFace flags anyMask: FlagFaceActive)
			ifTrue:[	leftFace == fillList first | noTest ifFalse:[self error:'Oops'].
					fillList remove: leftFace.
					fillList addFront: rightFace]
			ifFalse:[	rightFace == fillList first | noTest ifFalse:[self error:'Oops'].
					fillList remove: rightFace.
					fillList addFront: leftFace].
	] ifFalse:["rightFace active = leftFace active"
		(leftFace flags anyMask: FlagFaceActive) ifTrue:[
			(leftFace == fillList or:[rightFace == fillList first]) | noTest ifFalse:[self error:'Oops'].
			fillList remove: leftFace.
			fillList remove: rightFace.
			fillList searchForNewTopAtX: edge xValue y: yValue.
		] ifFalse:[
			leftFace dzdx <= rightFace dzdx
				ifTrue:[	fillList addFront: leftFace.
						fillList addBack: rightFace]
				ifFalse:[	fillList addFront: rightFace.
						fillList addBack: leftFace].
		].
	].
	leftFace flags: (leftFace flags bitXor: FlagFaceActive).
	rightFace flags: (rightFace flags bitXor: FlagFaceActive).
