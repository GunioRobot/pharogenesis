isParticipantFilterOn
	"return whether a non-trivial participant filter is installed"
	^participantFilter notNil and: [ participantFilter isEmpty not ]