addParticipantFilter
	"add a participant filter"

	| participant |
	mailDB ifNil: [^self].
	participant := self queryParticipantToFilter.
	participant ifNil: [^self].
	self addFilter: (CelesteParticipantFilter forParticipant: participant)