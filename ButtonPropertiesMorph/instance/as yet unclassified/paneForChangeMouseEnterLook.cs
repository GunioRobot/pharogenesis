paneForChangeMouseEnterLook

	| r |
	r _ self inARow: {
		self lockedString: ' Mouse-enter look ' translated.
	}.
	self allowDropsInto: r withIntent: #changeTargetMouseEnterLook.
	r setBalloonText: 'Drop another morph here to change the visual appearance of this button when the mouse enters it.' translated.
	^r
