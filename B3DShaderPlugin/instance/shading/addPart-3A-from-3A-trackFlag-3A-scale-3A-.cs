addPart: lightPart from: materialPart trackFlag: vbTrackFlag scale: scale
	"Add the given light part to the output color, scaled by the given scale factor.
	If the given flag is set in vbFlags then load the part from the primitive vertex"
	| rPart gPart bPart aPart |
	self var: #lightPart declareC:'float *lightPart'.
	self var: #materialPart declareC:'float *materialPart'.
	self var: #scale declareC:'double scale'.
	self var: #rPart declareC:'double rPart'.
	self var: #gPart declareC:'double gPart'.
	self var: #bPart declareC:'double bPart'.
	self var: #aPart declareC:'double aPart'.
	self inline: true.
	(vbFlags anyMask: vbTrackFlag) ifTrue:[
		rPart _ (vtxInColor at: 0) * (lightPart at: 0) * scale.
		gPart _ (vtxInColor at: 1) * (lightPart at: 1) * scale.
		bPart _ (vtxInColor at: 2) * (lightPart at: 2) * scale.
		aPart _ (vtxInColor at: 3) * (lightPart at: 3) * scale.
	] ifFalse:[
		"Note: This should be pre-computed."
		rPart _ (materialPart at: 0) * (lightPart at: 0) * scale.
		gPart _ (materialPart at: 1) * (lightPart at: 1) * scale.
		bPart _ (materialPart at: 2) * (lightPart at: 2) * scale.
		aPart _ (materialPart at: 3) * (lightPart at: 3) * scale.
	].
	vtxOutColor at: 0 put: (vtxOutColor at: 0) + rPart.
	vtxOutColor at: 1 put: (vtxOutColor at: 1) + gPart.
	vtxOutColor at: 2 put: (vtxOutColor at: 2) + bPart.
	vtxOutColor at: 3 put: (vtxOutColor at: 3) + aPart.