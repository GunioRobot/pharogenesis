determineClipFlags: vtxArray count: vtxCount
	"Determine the clip flags for all the vertices in the vertex array"
	| fullMask flags |
	self flag: #b3dPrimitive.
	fullMask _ InAllMask + OutAllMask.
	vtxArray upTo: vtxCount do:[:vtx|
		flags _ (self clipFlagsX: vtx rasterPosX 
							y: vtx rasterPosY 
							z: vtx rasterPosZ 
							w: vtx rasterPosW).
		vtx clipFlags: flags.
		fullMask _ fullMask bitAnd: flags.
	].
	^fullMask