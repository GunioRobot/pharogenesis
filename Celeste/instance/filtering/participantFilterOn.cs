participantFilterOn
	"Show only those messages where a specified user is either the sender or a receiver."

	participantFilter _
		(currentMsgID isNil)
			ifTrue: ['']
			ifFalse: [(mailDB getTOCentry: currentMsgID) from].
	participantFilter _ FillInTheBlank
		request: '''Participant:'' filter pattern?'
		initialAnswer: participantFilter.

	participantFilter _ participantFilter withBlanksTrimmed.
	self updateTOC.
	self changed: #isParticipantFilterOn.