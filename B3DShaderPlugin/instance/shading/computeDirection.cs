computeDirection
	"Compute the direction for the current light and vertex"
	| scale |
	self inline: true.
	self var: #scale declareC:'double scale'.
	(lightFlags anyMask: FlagPositional) ifTrue:[
		"Must compute the direction for this vertex"
		l2vDirection at: 0 put: (litVertex at: PrimVtxPositionX) - (primLight at: PrimLightPositionX).
		l2vDirection at: 1 put: (litVertex at: PrimVtxPositionY) - (primLight at: PrimLightPositionY).
		l2vDirection at: 2 put: (litVertex at: PrimVtxPositionZ) - (primLight at: PrimLightPositionZ).
		"l2vDistance _ self dotProductOf: l2vDirection with: l2vDirection."
		l2vDistance _ ((l2vDirection at: 0) * (l2vDirection at: 0)) +
						((l2vDirection at: 1) * (l2vDirection at: 1)) +
							((l2vDirection at: 2) * (l2vDirection at: 2)).
		(l2vDistance = 0.0 or:[l2vDistance = 1.0]) 
			ifFalse:[	l2vDistance _ l2vDistance sqrt.
					scale _ -1.0/l2vDistance].
		l2vDirection at: 0 put: (l2vDirection at: 0) * scale.
		l2vDirection at: 1 put: (l2vDirection at: 1) * scale.
		l2vDirection at: 2 put: (l2vDirection at: 2) * scale.
	] ifFalse:[
		(lightFlags anyMask: FlagDirectional) ifTrue:[
			l2vDirection at: 0 put: (primLight at: PrimLightDirectionX).
			l2vDirection at: 1 put: (primLight at: PrimLightDirectionY).
			l2vDirection at: 2 put: (primLight at: PrimLightDirectionZ).
		].
	].
