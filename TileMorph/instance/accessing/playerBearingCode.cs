playerBearingCode
	"Answer the actual Player object who will be the 'self' when the receiver is being asked to generate code"
	| anEditor |
	(anEditor _ self topEditor) ifNotNil: [^ anEditor playerScripted].
	^ (self nearestOwnerThat: [:m | m isAViewer]) scriptedPlayer