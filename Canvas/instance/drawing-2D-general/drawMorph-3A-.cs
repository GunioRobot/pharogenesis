drawMorph: aMorph
	(self isVisible: aMorph bounds) ifTrue:[self draw: aMorph]