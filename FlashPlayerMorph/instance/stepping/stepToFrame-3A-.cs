stepToFrame: frame
	| fullRect postDamage |
	frame = frameNumber ifTrue:[^self].
	frame > loadedFrames ifTrue:[^self].
	postDamage _ damageRecorder isNil.
	postDamage ifTrue:[damageRecorder _ FlashDamageRecorder new].
	frame = (frameNumber+1) ifTrue:[
		self stepToFrameForward: frame.
	] ifFalse:[
		activeMorphs _ activeMorphs select:[:any| false].
		submorphs do:[:m|
			(m isFlashMorph and:[m isFlashCharacter]) ifTrue:[
				m stepToFrame: frame.
				m visible ifTrue:[activeMorphs add: m].
			]].
	].
	frameNumber _ frame.
	playing ifTrue:[
		self playSoundsAt: frame.
		self executeActionsAt: frame.
	].
	(postDamage and:[owner notNil]) ifTrue:[
		damageRecorder updateIsNeeded ifTrue:[
			fullRect _ damageRecorder fullDamageRect: self localBounds.
			fullRect _ (self transform localBoundsToGlobal: fullRect).
			owner invalidRect: (fullRect insetBy: -1) from: self.
		].
	].
	postDamage ifTrue:[damageRecorder _ nil].