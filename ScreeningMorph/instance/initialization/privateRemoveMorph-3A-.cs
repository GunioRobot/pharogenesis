privateRemoveMorph: aMorph

	super privateRemoveMorph: aMorph.
	submorphs size = 1 ifTrue:
		[self bounds: submorphs first bounds]