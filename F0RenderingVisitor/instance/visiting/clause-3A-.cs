clause: aClause
	contour _ CosineInterpolator new at: 0 put: pitch; yourself.

	super clause: aClause.
	self renderPhraseAccentOrBoundaryTone: clause accent.

	self assignF0ToEvents