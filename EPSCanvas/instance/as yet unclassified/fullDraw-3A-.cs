fullDraw:aMorph
	super fullDraw:aMorph.
	morphLevel = 0 ifTrue: [
		target showpage.
	].