redButtonActivity
	| noSelectionMovement oldSelection selection nextSelection pt scrollFlag firstTime |
	noSelectionMovement _ true.
	scrollFlag _ false.
	oldSelection _ view selection.
	firstTime _ true.
	[sensor redButtonPressed | firstTime]
		whileTrue: 
			[selection _ view findSelection: (pt _ sensor cursorPoint).
			firstTime _ false.
			selection == nil ifTrue:  "Maybe out of box - check for auto-scroll"
					[pt y < view insetDisplayBox top ifTrue:
						[self scrollView: view list lineGrid.
						scrollFlag _ true.
						selection _ view firstShown].
					pt y > view insetDisplayBox bottom ifTrue:
						[self scrollView: view list lineGrid negated.
						scrollFlag _ true.
						selection _ view lastShown]].
			selection == nil ifFalse:
					[view moveSelectionBox: (nextSelection _ selection).
					nextSelection ~= oldSelection
						ifTrue: [noSelectionMovement _ false]]].
	nextSelection ~~ nil & (nextSelection = oldSelection
			ifTrue: [noSelectionMovement]
			ifFalse: [true]) ifTrue: [self changeModelSelection: nextSelection].
	scrollFlag ifTrue: [self moveMarker]