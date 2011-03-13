redButtonActivity
	| selection firstHit turningOn lastSelection pt scrollFlag |
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
				turningOn _ (model listSelectionAt: selection) not].
			view selection: selection.
			(model listSelectionAt: selection) == turningOn ifFalse:
				[view displaySelectionBox.
				model listSelectionAt: selection put: turningOn].
			lastSelection _ selection]].
	selection notNil ifTrue:
		["Normal protocol delivers change, so unchange first (ugh)"
		model listSelectionAt: selection put: (model listSelectionAt: selection) not.
		self changeModelSelection: selection].
	scrollFlag ifTrue: [self moveMarker]