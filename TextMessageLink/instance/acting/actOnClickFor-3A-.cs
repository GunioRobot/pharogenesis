actOnClickFor: evt
	| choice |
	choice := (PopUpMenu labels: 'view this attachment\save this attachment' withCRs) startUp.

	choice = 1 ifTrue: [
		"open a new viewer"
		message viewBody].

	choice = 2 ifTrue: [
		"save the mesasge"
		message save ].

	^true