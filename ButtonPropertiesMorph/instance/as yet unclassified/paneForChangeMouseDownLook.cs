paneForChangeMouseDownLook

	| r |
	r _ self inARow: {
		self lockedString: ' Mouse-down look ' translated.
	}.
	self allowDropsInto: r withIntent: #changeTargetMouseDownLook.
	r setBalloonText: 'Drop another morph here to change the visual appearance of this button when the mouse is clicked in it.' translated.
	^r
