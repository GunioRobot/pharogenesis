paneForChangeVisibleMorph

	| r |
	r _ self inARow: {
		self lockedString: ' Change morph ' translated.
	}.
	r on: #mouseDown send: #mouseDownEvent:for: to: self.
	self allowDropsInto: r withIntent: #changeTargetMorph.
	r setBalloonText: 'Drop another morph here to change the visual appearance of this button. Or click here to get a menu of possible replacement morphs.' translated.
	^r
