setupGStateForMorph:aMorph.
	target comment:'setupGState in EPSCanvas'.
	morphLevel == 1 ifTrue:[ 
		self writeSetupForRect:aMorph bounds.
		target translate:aMorph bounds origin negated.
	].
