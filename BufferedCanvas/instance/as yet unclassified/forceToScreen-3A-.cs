forceToScreen: rect

	mirrorOfScreen ifNil: [
		mirrorOfScreen _ (previousVersion ifNil: [Display]) deepCopy.
	].
	mirrorOfScreen copy: rect from: rect origin in: Display rule: Form over.
	dirtyRect _ dirtyRect ifNil: [rect] ifNotNil: [dirtyRect merge: rect].
