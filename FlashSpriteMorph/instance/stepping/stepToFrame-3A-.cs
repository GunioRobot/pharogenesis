stepToFrame: frame
	"Step to the given frame"
	| fullRect postDamage lastVisible resortNeeded |
	frame = frameNumber ifTrue:[^self].
	frame > loadedFrames ifTrue:[^self].
	postDamage _ damageRecorder isNil.
	postDamage ifTrue:[damageRecorder _ FlashDamageRecorder new].
	lastVisible _ nil.
	resortNeeded _ false.
	submorphs do:[:m|
		(m isFlashMorph and:[m isFlashCharacter]) ifTrue:[
			m stepToFrame: frame.
			m visible ifTrue:[
				(lastVisible notNil and:[lastVisible depth < m depth])
					ifTrue:[resortNeeded _ true].
				lastVisible _ m.
				(bounds containsRect: m bounds) ifFalse:[bounds _ bounds merge: m bounds].
			].
		].
	].
	resortNeeded ifTrue:[submorphs _ submorphs sortBy:[:m1 :m2| m1 depth > m2 depth]].
	frameNumber _ frame.
	playing ifTrue:[
		self playSoundsAt: frame.
		self executeActionsAt: frame.
	].
	(postDamage and:[owner notNil]) ifTrue:[
		damageRecorder updateIsNeeded ifTrue:[
			"fullRect _ damageRecorder fullDamageRect.
			fullRect _ (self transform localBoundsToGlobal: fullRect)."
			fullRect _ bounds.
			owner invalidRect: (fullRect insetBy: -1) from: self.
		].
	].
	postDamage ifTrue:[
		damageRecorder _ nil].