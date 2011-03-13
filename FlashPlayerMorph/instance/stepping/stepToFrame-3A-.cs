stepToFrame: frame
	| fullRect postDamage |
	frame = frameNumber ifTrue:[^self].
	frame > loadedFrames ifTrue:[^self].
	postDamage := damageRecorder isNil.
	postDamage ifTrue:[damageRecorder := FlashDamageRecorder new].
	frame = (frameNumber+1) ifTrue:[
		self stepToFrameForward: frame.
	] ifFalse:[
		activeMorphs := activeMorphs select:[:any| false].
		submorphs do:[:m|
			(m isFlashMorph and:[m isFlashCharacter]) ifTrue:[
				m stepToFrame: frame.
				m visible ifTrue:[activeMorphs add: m].
			]].
	].
	frameNumber := frame.
	playing ifTrue:[
		self playSoundsAt: frame.
		self executeActionsAt: frame.
	].
	(postDamage and:[owner notNil]) ifTrue:[
		damageRecorder updateIsNeeded ifTrue:[
			fullRect := damageRecorder fullDamageRect: self localBounds.
			fullRect := (self transform localBoundsToGlobal: fullRect).
			owner invalidRect: (fullRect insetBy: -1) from: self.
		].
	].
	postDamage ifTrue:[damageRecorder := nil].