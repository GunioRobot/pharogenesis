stylerStyled: styledCopyOfText

	controller deselectDuring: [
		displayContents text runs: styledCopyOfText runs.
		displayContents composeAll.
		controller recomputeInterval.
		controller setEmphasisHere.
		controller blinkParen.
		viewport ifNotNil:[
			unstyledAcceptText ifNil:[
				"don't displayView if accepting text (i.e. unstyledAcceptText not nil)
				because popup menus are painted over if we do" 
				self displayView]]]