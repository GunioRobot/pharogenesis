stepToFrameSilently: frame
	"Like stepToFrame but without executing any actions or starting sounds.
	Note: This method is not intended for fast replay."
	| fullRect postDamage |
	frame = frameNumber ifTrue:[^self].
	frame > loadedFrames ifTrue:[^self].
	postDamage := damageRecorder isNil.
	postDamage ifTrue:[damageRecorder := FlashDamageRecorder new].
	activeMorphs := activeMorphs select:[:any| false].
	submorphs do:[:m|
		(m isFlashMorph and:[m isFlashCharacter]) ifTrue:[
			m stepToFrame: frame.
			m visible ifTrue:[activeMorphs add: m].
		].
	].
	frameNumber := frame.
	(postDamage and:[owner notNil]) ifTrue:[
		damageRecorder updateIsNeeded ifTrue:[
			fullRect := damageRecorder fullDamageRect: self localBounds.
			fullRect := (self transform localBoundsToGlobal: fullRect).
			owner invalidRect: (fullRect insetBy: -1).
		].
	].
	postDamage ifTrue:[damageRecorder := nil].