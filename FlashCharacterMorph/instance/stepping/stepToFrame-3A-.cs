stepToFrame: frameNumber
	| m wasVisible isVisible noTransform cm |
	wasVisible _ self visible.
	self visible: (self visibleAtFrame: frameNumber).
	isVisible _ self visible.
	frame _ frameNumber.
	isVisible ifTrue:[
		m _ self matrixAtFrame: frame.
		cm _ self colorTransformAtFrame: frame.
		noTransform _ (m = transform) and:[colorTransform = cm].
		(noTransform and:[isVisible = wasVisible]) ifTrue:[^self]. "No change"
		((noTransform not) and:[wasVisible]) ifTrue:[
			"Invalidate with old transform"
			self changed.
		].
		self transform: m.
		self colorTransform: cm.
		((noTransform not) and:[isVisible]) ifTrue:[
			"Invalidate with new transform"
			self changed.
		].
		((noTransform) and:[isVisible ~~ wasVisible]) ifTrue:[
			"Invalidate with new transform"
			self changed.
		].
	] ifFalse:[
		wasVisible ifTrue:[self changed].
	].
	(isVisible ~~ wasVisible and:[self isSpriteHolder])
		ifTrue:[self activateSprites: isVisible].