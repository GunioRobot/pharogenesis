fullDraw: aMorph

	super fullDraw: aMorph.
	(morphLevel = 0 and: [aMorph pagesHandledAutomatically not]) ifTrue: [
		target showpage.
	].