toggleParticipantFilter
	"turn the participant filter on or off"
	participantFilter ifNil: [
		| filterString |
		filterString := self queryParticipantToFilter.
		filterString ifNil: [ ^self ].
		participantFilter := CelesteParticipantFilter forParticipant: filterString ]
	ifNotNil: [
		participantFilter := nil ].

	self filtersChanged.
