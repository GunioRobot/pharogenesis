isSafeToServe
	"True if all conditions are met to share safely. 
	(attends to mantis bug #0000519).
	Right now we reject worlds with FlashMorphs for subMorphs."

	(self findA: FlashMorph) ifNil: [^true].
	self inform: 'Can not share world if Squeaklogo is present. Collapse logo and try again'.
	^false