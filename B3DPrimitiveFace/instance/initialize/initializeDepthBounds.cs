initializeDepthBounds
	"Compute minZ/maxZ"
	v0 rasterPosZ <= v1 rasterPosZ ifTrue:[
		v1 rasterPosZ <= v2 rasterPosZ
			ifTrue:[minZ _ v0 rasterPosZ. maxZ _ v2 rasterPosZ]
			ifFalse:[v0 rasterPosZ <= v2 rasterPosZ
						ifTrue:[minZ _ v0 rasterPosZ. maxZ _ v1 rasterPosZ]
						ifFalse:[minZ _ v2 rasterPosZ. maxZ _ v1 rasterPosZ]].
	] ifFalse:[
		v2 rasterPosZ <= v1 rasterPosZ
			ifTrue:[minZ _ v2 rasterPosZ. maxZ _ v0 rasterPosZ]
			ifFalse:[v0 rasterPosZ <= v2 rasterPosZ
						ifTrue:[minZ _ v1 rasterPosZ. maxZ _ v2 rasterPosZ]
						ifFalse:[minZ _ v1 rasterPosZ. maxZ _ v0 rasterPosZ]].
	].
