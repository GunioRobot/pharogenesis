buttonSpecs
	"return specifications for the buttons that should be in the main window"
	^{
		self specForSubjectFilterButton.
		self specForParticipantFilterButton.
		self specForCustomFilterButton.
		self specForComposeButton.
		self specForReplyButton.
		self specForForwardButton.
		self specForMoveAgainButton.
		self specForDeleteButton.
		self specForOpenEmailPreferencesButton.
	 }
