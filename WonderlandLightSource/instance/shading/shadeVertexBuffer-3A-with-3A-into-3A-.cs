shadeVertexBuffer: vb with: aMaterial into: colorArray
	"This is the generic shading function similar to the primitive.
	Subclasses may implement optimized versions but should evaluate
	exactly to the same value as in here if they are to be converted into
	B3DPrimitiveLights."
	| color vtxArray ambientColor vtx direction distance scale cosAngle diffusePart specularPart specDir specularFactor |
	self flag: #b3dPrimitive.
	vtxArray _ vb vertexArray.
	(self hasAmbientPart and:[vb trackAmbientColor not])
		ifTrue:[ambientColor _ aMaterial ambientPart * lightColor ambientPart].
	(self hasDiffusePart and:[vb trackDiffuseColor not])
		ifTrue:[diffusePart _ aMaterial diffusePart].
	(self hasSpecularPart and:[vb trackSpecularColor not])
		ifTrue:[specularPart _ aMaterial specularPart].
	1 to: vb vertexCount do:[:i|
		vtx _ vtxArray at: i.
		color _ colorArray at: i.

		"Compute the direction and distance of light source from vertex"
		direction _ self computeDirectionTo: vtx.
		distance _ direction length.
		(distance = 0.0 or:[distance = 1.0]) ifFalse:[direction /= distance negated].

		"Compute the attenuation for the given distance"
		self isAttenuated
			ifTrue:[scale _ self computeAttenuationFor: distance]
			ifFalse:[scale _ 1.0].

		"Compute spot light factor"
		self hasSpot
			ifTrue:[scale _ scale * (self computeSpotFactor: direction)].

		"Compute ambient part"
		self hasAmbientPart ifTrue:[
			vb trackAmbientColor 
				ifTrue:[ambientColor _ vtx b3dColor * lightColor ambientPart].
			color += (ambientColor * scale).
		].

		"Compute the diffuse part of the light"
		self hasDiffusePart ifTrue:[
			"Compute angle from light->vertex to vertex normal"
			cosAngle _ vtx normal dot: direction.
			"For one-sided lighting negate cosAngle if necessary"
			(vb twoSidedLighting not and:[cosAngle < 0.0]) 
				ifTrue:[cosAngle _ 0.0 - cosAngle].
			"For two-sided lighting check if cosAngle > 0.0 meaning that it is a front face"
			cosAngle > 0.0 ifTrue:[
				vb trackDiffuseColor ifTrue:[diffusePart _ vtx b3dColor].
				color += (diffusePart * lightColor diffusePart * (cosAngle * scale)).
			].
		].

		"Compute specular part of the light"
		(self hasSpecularPart and:[aMaterial shininess > 0.0]) ifTrue:[
			vb useLocalViewer 
				ifTrue:[specDir _ direction - vtx position safelyNormalized]
				ifFalse:[specDir _ direction - (0@0@1.0)].
			cosAngle _ vtx normal dot: specDir.
			cosAngle > 0.0 ifTrue:[
				"Normalize the angle"
				cosAngle _ cosAngle / specDir length.
				"cosAngle should be somewhere between 0 and 1.
				If not, then the vertex normal was not normalized"
				cosAngle > 1.0 ifTrue:[
					specularFactor _ cosAngle raisedTo: aMaterial shininess.
				] ifFalse:[
					self flag: #TODO. "Use table lookup later"
					specularFactor _ cosAngle raisedTo: aMaterial shininess.
				].
				color += (specularPart * lightColor specularPart * specularFactor).
			].
		].
		self flag: #TODO. "Check specular part"
		colorArray at: i put: color.
	].