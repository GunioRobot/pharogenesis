redButtonActivity
	| selection firstHit turningOn lastSelection pt scrollFlag |
	model okToChange ifFalse: [^ self].
		"Don't change selection if model refuses to unlock"
	firstHit := true.
	scrollFlag := false.
	lastSelection := 0.
	[sensor redButtonPressed] whileTrue: 
		[selection := view findSelection: (pt := sensor cursorPoint).
		selection == nil ifTrue:  "Maybe out of box - check for auto-scroll"
			[pt y < view insetDisplayBox top ifTrue:
				[self scrollView: view list lineGrid.
				scrollFlag := true.
				selection := view firstShown].
			pt y > view insetDisplayBox bottom ifTrue:
				[self scrollView: view list lineGrid negated.
				scrollFlag := true.
				selection := view lastShown]].
		(selection == nil or: [selection = lastSelection]) ifFalse: 
			[firstHit ifTrue:
				[firstHit := false.
				turningOn := (view listSelectionAt: selection) not].
			view selection: selection.
			(view listSelectionAt: selection) == turningOn ifFalse:
				[view displaySelectionBox.
				view listSelectionAt: selection put: turningOn].
			lastSelection := selection]].
	selection notNil ifTrue:
		["Normal protocol delivers change, so unchange first (ugh)"
		view listSelectionAt: selection put: (view listSelectionAt: selection) not.
		self changeModelSelection: selection].
	scrollFlag ifTrue: [self moveMarker]