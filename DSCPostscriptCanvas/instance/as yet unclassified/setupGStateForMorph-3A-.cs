setupGStateForMorph:aMorph
	" position the morph on the page  "
	morphLevel == 2 ifTrue:[ 
		self writeSetupForRect:aMorph bounds.
		target translate:self pageOffset.
		target translate:aMorph bounds origin negated.
	].
