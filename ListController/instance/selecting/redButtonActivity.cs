redButtonActivity
	| noSelectionMovement oldSelection selection nextSelection pt scrollFlag firstTime |
	noSelectionMovement := true.
	scrollFlag := false.
	oldSelection := view selection.
	firstTime := true.
	[sensor redButtonPressed | firstTime]
		whileTrue: 
			[selection := view findSelection: (pt := sensor cursorPoint).
			firstTime := false.
			selection == nil ifTrue:  "Maybe out of box - check for auto-scroll"
					[pt y < view insetDisplayBox top ifTrue:
						[self scrollView: view list lineGrid.
						scrollFlag := true.
						selection := view firstShown].
					pt y > view insetDisplayBox bottom ifTrue:
						[self scrollView: view list lineGrid negated.
						scrollFlag := true.
						selection := view lastShown]].
			selection == nil ifFalse:
					[view moveSelectionBox: (nextSelection := selection).
					nextSelection ~= oldSelection
						ifTrue: [noSelectionMovement := false]]].
	nextSelection ~~ nil & (nextSelection = oldSelection
			ifTrue: [noSelectionMovement]
			ifFalse: [true]) ifTrue: [self changeModelSelection: nextSelection].
	scrollFlag ifTrue: [self moveMarker]