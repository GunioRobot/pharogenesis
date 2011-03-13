stepToFrame: frame
	"Step to the given frame"
	| fullRect postDamage lastVisible resortNeeded |
	frame = frameNumber ifTrue:[^self].
	frame > loadedFrames ifTrue:[^self].
	postDamage := damageRecorder isNil.
	postDamage ifTrue:[damageRecorder := FlashDamageRecorder new].
	lastVisible := nil.
	resortNeeded := false.
	submorphs do:[:m|
		(m isFlashMorph and:[m isFlashCharacter]) ifTrue:[
			m stepToFrame: frame.
			m visible ifTrue:[
				(lastVisible notNil and:[lastVisible depth < m depth])
					ifTrue:[resortNeeded := true].
				lastVisible := m.
				(bounds containsRect: m bounds) ifFalse:[bounds := bounds merge: m bounds].
			].
		].
	].
	resortNeeded ifTrue:[submorphs := submorphs sortBy:[:m1 :m2| m1 depth > m2 depth]].
	frameNumber := frame.
	playing ifTrue:[
		self playSoundsAt: frame.
		self executeActionsAt: frame.
	].
	(postDamage and:[owner notNil]) ifTrue:[
		damageRecorder updateIsNeeded ifTrue:[
			"fullRect := damageRecorder fullDamageRect.
			fullRect := (self transform localBoundsToGlobal: fullRect)."
			fullRect := bounds.
			owner invalidRect: (fullRect insetBy: -1) from: self.
		].
	].
	postDamage ifTrue:[
		damageRecorder := nil].