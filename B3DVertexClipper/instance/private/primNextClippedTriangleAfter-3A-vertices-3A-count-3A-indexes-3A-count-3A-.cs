primNextClippedTriangleAfter: firstIndex vertices: vtxArray count: vtxCount indexes: idxArray count: idxCount
	"Find the next partially clipped triangle from the vertex buffer and return its index.
	If there are no more partially clipped triangles return zero."
	| triMask |
	self flag: #b3dPrimitive.
	firstIndex to: idxCount by: 3 do:[:i|
		triMask _
			((vtxArray at: (idxArray at: i)) clipFlags bitAnd:
				(vtxArray at: (idxArray at: i+1)) clipFlags) bitAnd:
					(vtxArray at: (idxArray at: i+2)) clipFlags.
		"Check if tri is completely inside"
		(triMask allMask: InAllMask) ifFalse:[
			"Tri is not completely inside -> needs clipping."
			(triMask anyMask: OutAllMask) ifTrue:[
				"tri is completely outside. Store all zeros"
				idxArray at: i put: 0.
				idxArray at: i+1 put: 0.
				idxArray at: i+2 put: 0.
			] ifFalse:[
				"tri must be partially clipped."
				^i
			].
		].
	].
	^0 "No more entries"