queryParticipantToFilter
	"ask the user for a string to use as a participant  filter"

	| participant guess |
	guess := currentMsgID isNil 
				ifTrue: ['']
				ifFalse: [(mailDB getTOCentry: currentMsgID) from].
	participant := FillInTheBlank request: 'Participant filter pattern?'
				initialAnswer: guess.
	participant ifNotNil: 
			[participant := participant withBlanksTrimmed.
			participant isEmpty ifTrue: [participant := nil]].
	^participant