shadeVertex
	| cosAngle specularFactor |
	self var: #cosAngle declareC:'double cosAngle'.
	self var: #specularFactor declareC:'double specularFactor'.
	self computeDirection.
	self computeAttenuation.

	(lightFlags anyMask: FlagHasSpot) ifTrue:[
		lightScale _ lightScale * self computeSpotFactor.
	].

	"Compute ambient and diffuse part only if lightScale is non-zero."
	(lightScale > 0.001) ifTrue:[
		"Compute the ambient part"
		(lightFlags anyMask: FlagAmbientPart) ifTrue:[
			self addPart: (primLight + AmbientPart) 
				from: primMaterial + AmbientPart 
				trackFlag: VBTrackAmbient 
				scale: lightScale.
		].

		"Compute the diffuse part"
		(lightFlags anyMask: FlagDiffusePart) ifTrue:[
			"Compute angle from light->vertex to vertex normal"
			cosAngle _ self dotProductOfFloat: (litVertex + PrimVtxNormal) withDouble: l2vDirection.
			"For one-sided lighting negate cosAngle if necessary"
			((vbFlags bitAnd: VBTwoSidedLighting) = 0 and:[cosAngle < 0.0])
				ifTrue:[cosAngle _ 0.0 - cosAngle].
			"For two-sided lighting check if cosAngle > 0.0 meaning that it is a front face"
			cosAngle > 0.0 ifTrue:[
				self addPart: primLight + DiffusePart 
					from: primMaterial + DiffusePart 
					trackFlag: VBTrackDiffuse 
					scale: lightScale * cosAngle.
			].
		].
	]. "lightScale > 0.001"

	"Compute the specular part"
	((lightFlags anyMask: FlagSpecularPart) and:[
		(primMaterial at: MaterialShininess) > 0.0]) ifTrue:[
		"Compute specular part"
		l2vSpecDir at: 0 put: (l2vDirection at: 0).
		l2vSpecDir at: 1 put: (l2vDirection at: 1).
		l2vSpecDir at: 2 put: (l2vDirection at: 2).
		(vbFlags anyMask: VBUseLocalViewer) 
			ifTrue:[self computeSpecularDirection]
			ifFalse:[l2vSpecDir at: 2 put: (l2vSpecDir at: 2) - 1.0].
		cosAngle _ self dotProductOfFloat: (litVertex + PrimVtxNormal) withDouble: l2vSpecDir.
		cosAngle > 0.0 ifTrue:[
			"Normalize the angle"
			cosAngle _ cosAngle * (self inverseLengthOfDouble: l2vSpecDir).
			"cosAngle should be somewhere between 0 and 1.
			If not, then the vertex normal was not normalized"
			cosAngle > 1.0 ifTrue:[
				specularFactor _ cosAngle raisedTo: (primMaterial at: MaterialShininess).
			] ifFalse:[
				cosAngle = 0.0 
					ifTrue:[specularFactor _ 1.0]
					ifFalse:[specularFactor _ cosAngle raisedTo: (primMaterial at: MaterialShininess)].
			].
			self addPart: primLight + SpecularPart 
				from: primMaterial + SpecularPart 
				trackFlag: VBTrackSpecular 
				scale: specularFactor.
		].
	].