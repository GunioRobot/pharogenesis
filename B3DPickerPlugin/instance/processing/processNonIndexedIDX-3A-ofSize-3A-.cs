processNonIndexedIDX: vtxArray ofSize: vtxSize
	| vtxPtr zValue wValue minZ minIndex |
	self var: #vtxArray declareC:'float *vtxArray'.
	self var: #vtxPtr declareC:'float *vtxPtr'.
	self var: #wValue declareC:'double wValue'.
	self var: #zValue declareC:'double zValue'.
	self var: #minZ declareC:'double minZ'.
	minZ _ 10.0.
	minIndex _ 0.
	vtxPtr _ vtxArray.
	1 to: vtxSize do:[:i|
		zValue _ vtxPtr at: PrimVtxRasterPosZ.
		wValue _ vtxPtr at: PrimVtxRasterPosW.
		wValue = 0.0 ifFalse:[zValue _ zValue / wValue].
		(minIndex = 0 or:[zValue < minZ]) ifTrue:[
			minIndex _ i.
			minZ _ zValue].
	].
	^minIndex