primNextClippedQuadAfter: firstIndex vertices: vtxArray count: vtxCount indexes: idxArray count: idxCount
	"Find the next partially clipped quad from the vertex buffer and return its index.
	If there are no more partially clipped quads return zero."
	| quadMask |
	self flag: #b3dPrimitive.
	firstIndex to: idxCount by: 4 do:[:i|
		quadMask _
			((vtxArray at: (idxArray at: i)) clipFlags bitAnd:
				(vtxArray at: (idxArray at: i+1)) clipFlags) bitAnd:
					((vtxArray at: (idxArray at: i+2)) clipFlags bitAnd:
						(vtxArray at: (idxArray at: i+3)) clipFlags).
		"Check if quad is completely inside"
		(quadMask allMask: InAllMask) ifFalse:[
			"Quad is not completely inside -> needs clipping."
			(quadMask anyMask: OutAllMask) ifTrue:[
				"quad is completely outside. Store all zeros"
				idxArray at: i put: 0.
				idxArray at: i+1 put: 0.
				idxArray at: i+2 put: 0.
				idxArray at: i+3 put: 0.
			] ifFalse:[
				"quad must be partially clipped."
				^i
			].
		].
	].
	^0 "No more entries"