redButtonActivity
	| selection firstHit turningOn lastSelection pt scrollFlag |
	model okToChange ifFalse: [^ self].
		"Don't change selection if model refuses to unlock"
	firstHit _ true.
	scrollFlag _ false.
	lastSelection _ 0.
	[sensor redButtonPressed] whileTrue: 
		[selection _ view findSelection: (pt _ sensor cursorPoint).
		selection == nil ifTrue:  "Maybe out of box - check for auto-scroll"
			[pt y < view insetDisplayBox top ifTrue:
				[self scrollView: view list lineGrid.
				scrollFlag _ true.
				selection _ view firstShown].
			pt y > view insetDisplayBox bottom ifTrue:
				[self scrollView: view list lineGrid negated.
				scrollFlag _ true.
				selection _ view lastShown]].
		(selection == nil or: [selection = lastSelection]) ifFalse: 
			[firstHit ifTrue:
				[firstHit _ false.
				turningOn _ (view listSelectionAt: selection) not].
			view selection: selection.
			(view listSelectionAt: selection) == turningOn ifFalse:
				[view displaySelectionBox.
				view listSelectionAt: selection put: turningOn].
			lastSelection _ selection]].
	selection notNil ifTrue:
		["Normal protocol delivers change, so unchange first (ugh)"
		view listSelectionAt: selection put: (view listSelectionAt: selection) not.
		self changeModelSelection: selection].
	scrollFlag ifTrue: [self moveMarker]