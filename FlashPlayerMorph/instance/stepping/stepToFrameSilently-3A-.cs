stepToFrameSilently: frame
	"Like stepToFrame but without executing any actions or starting sounds.
	Note: This method is not intended for fast replay."
	| fullRect postDamage |
	frame = frameNumber ifTrue:[^self].
	frame > loadedFrames ifTrue:[^self].
	postDamage _ damageRecorder isNil.
	postDamage ifTrue:[damageRecorder _ FlashDamageRecorder new].
	activeMorphs _ activeMorphs select:[:any| false].
	submorphs do:[:m|
		(m isFlashMorph and:[m isFlashCharacter]) ifTrue:[
			m stepToFrame: frame.
			m visible ifTrue:[activeMorphs add: m].
		].
	].
	frameNumber _ frame.
	(postDamage and:[owner notNil]) ifTrue:[
		damageRecorder updateIsNeeded ifTrue:[
			fullRect _ damageRecorder fullDamageRect: self localBounds.
			fullRect _ (self transform localBoundsToGlobal: fullRect).
			owner invalidRect: (fullRect insetBy: -1).
		].
	].
	postDamage ifTrue:[damageRecorder _ nil].