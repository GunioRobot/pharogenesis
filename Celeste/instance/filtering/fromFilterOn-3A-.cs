fromFilterOn: aSwitch
	"Show only those messages from the same person as the currently selected message. The user is given a chance to edit the pattern string used to match 'From:' fields."

	fromFilter _
		(currentMsgID isNil)
			ifTrue: ['']
			ifFalse: [(mailDB getTOCentry: currentMsgID) from].
	fromFilter _ FillInTheBlank
		request: '''From:'' filter pattern?'
		initialAnswer: fromFilter.
	fromFilter = '' ifTrue: [aSwitch turnOff.  ^self]. "User cancelled, so turn off the switch"
	fromFilter _ fromFilter withoutTrailingBlanks.
	self updateTOC.