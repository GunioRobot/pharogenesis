validateDepthSetup
	oneOverArea = 0.0 ifTrue:[^self].
	(v0 rasterPosZ - (self zValueAtX: v0 rasterPosX y: v0 rasterPosY)) abs >= 1.0e-10 
		ifTrue:[self error:'Depth problem'].
	(v1 rasterPosZ - (self zValueAtX: v1 rasterPosX y: v1 rasterPosY)) abs >= 1.0e-10 
		ifTrue:[self error:'Depth problem'].
	(v2 rasterPosZ - (self zValueAtX: v2 rasterPosX y: v2 rasterPosY)) abs >= 1.0e-10 
		ifTrue:[self error:'Depth problem'].