buttonSpecs
	"return specifications for the buttons that should be visible"
	^{
		self specForAddSubjectFilterButton.
		self specForAddParticipantFilterButton.
		self specForNamedFilterButton.
		self specForComposeButton.
		self specForReplyButton.
		self specForForwardButton.
		self specForMoveAgainButton.
		self specForDeleteButton.
		self specForDeleteSpamButton.
	 }
