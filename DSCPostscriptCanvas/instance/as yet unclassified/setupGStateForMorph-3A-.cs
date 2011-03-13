setupGStateForMorph: aMorph
	" position the morph on the page  "

	morphLevel == (topLevelMorph pagesHandledAutomatically ifTrue: [2] ifFalse: [1]) ifTrue:[ 
		target print: '% pageOffset'; cr.
		target translate: self pageOffset.
		self writeSetupForRect: aMorph bounds.
		target print: '% negate morph offset';cr.
		target translate: aMorph bounds origin negated.
	].
